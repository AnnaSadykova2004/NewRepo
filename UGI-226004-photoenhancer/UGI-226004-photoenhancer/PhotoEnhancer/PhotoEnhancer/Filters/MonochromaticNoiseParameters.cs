using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class MonochromaticNoiseParameters : IParameters
    {
        public double Coefficient { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Интенсивность шума",
                    MinValue = 0,
                    MaxValue =1,
                    DefaultValue = 0,
                    Increment = 0.01
                }
            };
        }

        public void SetValues(double[] values)
        {
            Coefficient = values[0];
        }

    }
}
