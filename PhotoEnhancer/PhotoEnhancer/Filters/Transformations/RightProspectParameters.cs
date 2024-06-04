using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class RightProspectParameters : IParameters
    {
        [ParameterInfo(Name = "Процент сужения",
                    MinValue = 0,
                    MaxValue = 100,
                    DefaultValue = 100,
                    Increment = 5)]
        public double PercentOfNarrowing { get; set; }
    }
}
