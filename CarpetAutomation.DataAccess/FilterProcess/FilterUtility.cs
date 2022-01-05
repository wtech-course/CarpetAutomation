using System;
using System.Collections.Generic;
using System.Text;

namespace CarpetAutomation.DataAccess.FilterProcess
{
    public class FilterUtility
    {
        public enum FilterOptions
        {
            StartsWith = 1,
            EndsWith,
            Contains,
            DoesNotContain,
            IsEmpty,
            IsNotEmpty,
            IsGreaterThan,
            IsGreaterThanOrEqualTo,
            IsLessThan,
            IsLessThanOrEqualTo,
            IsEqualTo,
            IsNotEqualTo
        }
    }
}
