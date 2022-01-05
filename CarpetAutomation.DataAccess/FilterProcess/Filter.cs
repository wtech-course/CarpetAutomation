
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static CarpetAutomation.DataAccess.FilterProcess.FilterUtility;

namespace CarpetAutomation.DataAccess.FilterProcess
{
    public class Filter<TEntity>
    {
        //public static IEnumerable<TEntity> FilterData(IEnumerable<FilterParams> filterParams, IEnumerable<TEntity> data)
        //{
        //    IEnumerable<string> distinctColumns = filterParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)).Select(x => x.ColumnName).Distinct();
        //    foreach (string colName in distinctColumns)
        //    {
        //        var filtercolumn = typeof(TEntity).GetProperty(colName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
        //        if (filtercolumn != null)
        //        {
        //            IEnumerable<FilterParams> filterValues = filterParams.Where(w => w.ColumnName.Equals(colName)).Distinct();
        //            if (filterValues.Count() > 1)
        //            {
        //                IEnumerable<TEntity> colData = Enumerable.Empty<TEntity>();
        //                foreach (var val in filterValues)
        //                {
        //                    colData = colData.Concat(FilterData(val.FilterOption, data, filtercolumn, val.FilterValue));
        //                }
        //            }
        //            else
        //            {
        //                data = FilterData(filterValues.FirstOrDefault().FilterOption, data, filtercolumn, filterValues.FirstOrDefault().FilterValue);
        //            }
        //        }
        //    }
        //}

        //private static IEnumerable<TEntity> FilterData(FilterOptions filterOption, IEnumerable<TEntity> data, PropertyInfo filtercolumn, string filterValue)
        //{
        //    int outValue;
        //    DateTime dateValue;
        //    switch (filterOption)
        //    {
        //        case FilterOptions.StartsWith:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) != null && filtercolumn.GetValue(x, null).ToString().ToLower().StartsWith(filterValue.ToString().ToLower())).ToList();
        //            break;
        //        case FilterOptions.EndsWith:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) != null && filtercolumn.GetValue(x, null).ToString().ToLower().EndsWith(filterValue.ToString().ToLower())).ToList();
        //            break;
        //        case FilterOptions.Contains:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) != null && filtercolumn.GetValue(x, null).ToString().ToLower().Contains(filterValue.ToString().ToLower())).ToList();
        //            break;
        //        case FilterOptions.DoesNotContain:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) == null || filtercolumn.GetValue(x, null) != null && !filtercolumn.GetValue(x, null).ToString().ToLower().Contains(filterValue.ToString().ToLower())).ToList();
        //            break;
        //        case FilterOptions.IsEmpty:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) == null ||
        //              (filtercolumn.GetValue(x, null) != null && filtercolumn.GetValue(x, null).ToString() == string.Empty)).ToList();
        //            break;
        //        case FilterOptions.IsNotEmpty:
        //            data = data.Where(x => filtercolumn.GetValue(x, null) != null && filtercolumn.GetValue(x, null).ToString() != string.Empty).ToList();
        //            break;
        //        case FilterOptions.IsGreaterThan:
        //            if ((filtercolumn.PropertyType == typeof(Int32) || filtercolumn.PropertyType == typeof(Nullable<Int32>)) && Int32.TryParse(filterValue, out outValue))
        //            {
        //                data = data.Where(x => Convert.ToInt32(filtercolumn.GetValue(x, null)) > outValue).ToList();
        //            }
        //            else if ((filtercolumn.PropertyType == typeof(Nullable<DateTime>)) && DateTime.TryParse(filterValue, out dateValue))
        //            {
        //                data = data.Where(w => Convert.ToDateTime(filtercolumn.GetValue(w, null)) >= dateValue).ToList();
        //            }
        //            break;
        //        case FilterOptions.IsGreaterThanOrEqualTo:
        //            break;
        //        case FilterOptions.IsLessThan:
        //            break;
        //        case FilterOptions.IsLessThanOrEqualTo:
        //            break;
        //        case FilterOptions.IsEqualTo:
        //            break;
        //        case FilterOptions.IsNotEqualTo:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
