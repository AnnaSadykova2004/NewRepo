using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        public override Photo Process(Photo original, TParameters parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (var x = 0; x < original.Width; x++)
                for (var y = 0; y < original.Height; y++)
                    newPhoto[x, y] = ProcessPixel(original[x, y], parameters);

            return newPhoto;
        }

        public abstract Pixel ProcessPixel(Pixel p, TParameters parameters);
    }
}
