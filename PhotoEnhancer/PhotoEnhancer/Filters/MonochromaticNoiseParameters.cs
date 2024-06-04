using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MonochromaticNoiseParameters : IParameters
    {
        [ParameterInfo(Name = "Интенсивность шума",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0,
                    Increment = 0.01)]
        public double Coefficient { get; set; }
    }
}
