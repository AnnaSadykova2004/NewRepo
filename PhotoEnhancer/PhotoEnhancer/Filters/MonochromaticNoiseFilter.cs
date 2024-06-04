using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MonochromaticNoiseFilter : PixelFilter<MonochromaticNoiseParameters>
    {
        Random rnd = new Random();
        public override Pixel ProcessPixel(Pixel p, MonochromaticNoiseParameters parameters)
        {
            var q = Convertors.RGBToHSL(p);

            double r = rnd.NextDouble();
            
            var noise = parameters.Coefficient * r + (1 - parameters.Coefficient) * q.L;


            return Convertors.HSLToRGB(new PixelHSL(q.H, q.S, noise));
        } 

        public override string ToString()
        {
            return "Монохромный шум";
        }

    }
}
