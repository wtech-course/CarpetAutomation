using System;
using System.Collections.Generic;
using System.Text;
using static CarpetAutomation.DataAccess.FilterProcess.FilterUtility;

namespace CarpetAutomation.DataAccess.FilterProcess
{
    public class FilterParams
    {
        public string ColumnName { get; set; } = string.Empty;
        public string FilterValue { get; set; } = string.Empty;
        public FilterOptions FilterOption { get; set; } = FilterOptions.Contains;
    }
}
