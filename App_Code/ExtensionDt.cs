using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExtensionDt
/// </summary>
public class ExtensionDt
{
    public static DataTable ToDataTable<AssetsResponseResultModel>( List<AssetsResponseResultModel> data)
    {
        PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(AssetsResponseResultModel));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (AssetsResponseResultModel item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }
            table.Rows.Add(values);
        }
        return table;
    }
}