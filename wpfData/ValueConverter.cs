using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using wpfData_Step_4.Model;

namespace wpfData_Step_4
{
    public class FullNameValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //המרה בטוחה של האובייקט לעצם המבוקש
            User p = value as User; 
            if (p == null) //לא עצם מסוג איש
                return null;
            else
                return p.LastName + " " + p.FirstName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }



    public class SalaryValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Teacher teacher = value as Teacher;  //type checked
            if (teacher == null)
                return null;
            else
                return String.Format("{0:n0}$",teacher.Salary);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
