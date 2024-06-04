using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class HueFilter : PixelFilter<HueParameters>
    {
        public override Pixel ProcessPixel(Pixel p, HueParameters parameters)
        {
            var q = Convertors.RGBToHSL(p);

            var hue = q.H * 360 + parameters.Shift;

            if (hue >= 360)
                hue -= 360;

            return Convertors.HSLToRGB(new PixelHSL(hue / 360, q.S, q.L));
        } 

        public override string ToString()
        {
            return "Оттенок";
        }
    }
}
