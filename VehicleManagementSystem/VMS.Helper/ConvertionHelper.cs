using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace VMS.Helper
{
    public class ConvertionHelper
    {
        public static List<T> ConvertDataTableToEnityList<T>(DataTable dataTable) where T : new()
        {
            List<T> result = new List<T>();
            FieldInfo[] fields = typeof (T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();
                foreach (FieldInfo f in fields)
                {
                    if (!row.Table.Columns.Contains(f.Name)) continue;
                    Type type = row[f.Name].GetType();
                    if (type == Type.GetType("DBNull") || type == Type.GetType("System.DBNull"))
                    {
                        f.SetValue(obj, null);
                    }
                    else if (type == Type.GetType("String") || type == Type.GetType("System.String"))
                    {
                        f.SetValue(obj, row[f.Name].ToString().Trim());
                    }
                    else
                    {
                        f.SetValue(obj, row[f.Name]);
                    }

                }

                result.Add(obj);
            }

            return result;
        }

        public static T ConvertDataRowToEnity<T>(DataRow row) where T : new()
        {
            T result = new T();
            FieldInfo[] fields = typeof (T).GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo f in fields)
            {
                if (!row.Table.Columns.Contains(f.Name)) continue;
                Type type = row[f.Name].GetType();
                if (type == Type.GetType("DBNull") || type == Type.GetType("System.DBNull"))
                {
                    f.SetValue(result, null);
                }
                else if (type == Type.GetType("String") || type == Type.GetType("System.String"))
                {
                    f.SetValue(result, row[f.Name].ToString().Trim());
                }
                else
                {
                    f.SetValue(result, row[f.Name]);
                }
            }

            return result;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public static List<T> ToList<T>(DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<T> result = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T item = CreateItemFromRow<T>(row, properties);
                result.Add(item);
            }

            return result;
        }

        public static List<T> ToList<T>(DataTable table, Dictionary<string, string> mappings) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<T> result = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T item = CreateItemFromRow<T>(row, properties, mappings);
                result.Add(item);
            }

            return result;
        }

        public static T ToEntity<T>(DataRow row) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            T item = CreateItemFromRow<T>(row, properties);

            return item;
        }

        public static T ToEntity<T>(DataRow row, Dictionary<string, string> mappings) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            T item = CreateItemFromRow<T>(row, properties, mappings);

            return item;
        }

        private static T CreateItemFromRow<T>(DataRow row, IEnumerable<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (PropertyInfo property in properties)
            {
                if (!row.Table.Columns.Contains(property.Name)) continue;
                Type type = row[property.Name].GetType();
                if (type == Type.GetType("DBNull") || type == Type.GetType("System.DBNull"))
                {
                    property.SetValue(item, null, null);
                }
                else if (type == Type.GetType("String") || type == Type.GetType("System.String"))
                {
                    property.SetValue(item, row[property.Name].ToString().Trim(), null);
                }
                else
                {
                    property.SetValue(item, row[property.Name], null);
                }
            }
            return item;
        }

        private static T CreateItemFromRow<T>(DataRow row, IEnumerable<PropertyInfo> properties, Dictionary<string, string> mappings) where T : new()
        {
            T item = new T();
            foreach (PropertyInfo property in properties)
            {
                if (!row.Table.Columns.Contains(property.Name)) continue;
                if (mappings.ContainsKey(property.Name))
                {
                    Type type = row[property.Name].GetType();
                    if (type == Type.GetType("DBNull") || type == Type.GetType("System.DBNull"))
                    {
                        property.SetValue(item, null, null);
                    }
                    else if (type == Type.GetType("String") || type == Type.GetType("System.String"))
                    {
                        property.SetValue(item, row[property.Name].ToString().Trim(), null);
                    }
                    else
                    {
                        property.SetValue(item, row[property.Name], null);
                    }

                }
                    
            }
            return item;
        }

        public static List<string> ToListString(DataTable dt)
        {
            List<string> result = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(row[0].ToString().Trim());
            }

            return result;
        }
    }
}
