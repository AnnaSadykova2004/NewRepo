using PhotoEnhancer.Filters.Transformations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            //mainForm.AddFilter(new LighteningFilter());
            //mainForm.AddFilter(new GrayScaleFilter());
            //mainForm.AddFilter(new HueFilter());

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (p, parameters) => p * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (p, parameters) =>
                {
                    var lightness = 0.3 * p.R + 0.6 * p.G + 0.1 * p.B;
                    return new Pixel(lightness, lightness, lightness);
                }
                ));

            Random rnd = new Random();
            mainForm.AddFilter(new PixelFilter<MonochromaticNoiseParameters>(
                "Монохромный шум",
                (p, parameters) =>
                {
                    var q = Convertors.RGBToHSL(p);


                    double r = rnd.NextDouble();

                    var noise = parameters.Coefficient * r + (1 - parameters.Coefficient) * q.L;

                    return Convertors.HSLToRGB(new PixelHSL(q.H, q.S, noise));

                }
                ));

            mainForm.AddFilter(new PixelFilter<HueParameters>(
                "Оттенок",
                (p, parameters) =>
                {
                    var q = Convertors.RGBToHSL(p);

                    var hue = q.H * 360 + parameters.Shift;

                    if (hue >= 360)
                        hue -= 360;

                    return Convertors.HSLToRGB(new PixelHSL(hue / 360, q.S, q.L));
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч.с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Зерк. отражение отн. главной диагонали",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(point.Y, point.X)
                ));

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол", new RotationTransformer()));

            mainForm.AddFilter(new TransformFilter<RightPerspectiveParameters>(
                "Перспектива вправо", new RightPerspectiveTransformer()));

            Application.Run(mainForm);
        }
    }
}
