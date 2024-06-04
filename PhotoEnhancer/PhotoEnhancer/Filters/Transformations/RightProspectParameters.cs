using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class RightProspectParameters : IParameters
    {
        public double PercentOfNarrowing {  get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Процент сужения",
                    MinValue = 0,
                    MaxValue =100,
                    DefaultValue = 100,
                    Increment = 5
                }
            };
        }

        public void SetValues(double[] values)
        {
            PercentOfNarrowing = values[0];
        }
    }
}
