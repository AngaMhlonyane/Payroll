using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Helpers
{
    using System;
    public static class PayrollHelpers
    {
        public static decimal RoundToTwoDecimalPlaces(decimal value)
        {
            return Math.Round(value, 2);
        }

        public static decimal EnsurePositiveValue(decimal value)
        {
            return value < 0 ? 0 : value;
        }
    }
}