using System;
using System.Collections.Generic;
using System.Text;

namespace ZenfolioCandidateTest
{
    public class NumberResult
    {
        /* The Mean is the usual average (1 + 2 + 3 + 4) / 4 */
        public decimal Mean { get; set; }
        /* The median is the middle value */
        public decimal Median { get; set; }
        /* The mode is the number that is repeated more often than any other */
        public decimal[] Mode { get; set; }
        /* The Range is max value - min value */
        public decimal Range { get; set; }
    }
}
