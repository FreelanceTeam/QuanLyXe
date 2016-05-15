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
    }

    /// <summary>
    /// Provides a generic collection that supports data binding and additionally supports sorting.
    /// See http://msdn.microsoft.com/en-us/library/ms993236.aspx
    /// If the elements are IComparable it uses that; otherwise compares the ToString()
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SortableBindingList<T> : BindingList<T> where T : class
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        public SortableBindingList(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented
        /// </summary>
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            _isSorted = false; //thanks Luca
        }

        /// <summary>
        /// Sorts the items if overridden in a derived class
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = Items as List<T>;
            if (list == null) return;

            list.Sort(Compare);

            _isSorted = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


        private int Compare(T lhs, T rhs)
        {
            int result = OnComparison(lhs, rhs);
            //invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; //nulls are equal
            }
            if (rhsValue == null)
            {
                return 1; //first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }
    }
}
