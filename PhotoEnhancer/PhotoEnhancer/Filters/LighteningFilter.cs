using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter<LighteningParameters>
    {
        public override Pixel ProcessPixel(Pixel p, LighteningParameters parameters)
        {
            return p * parameters.Coefficient;
        } 

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
