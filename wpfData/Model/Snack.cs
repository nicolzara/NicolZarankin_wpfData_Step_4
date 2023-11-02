using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfData_Step_4.Model
{
    public class Snack : BaseEntity
    {
        private string name;
        private int calories;

        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }
    }

    public class SnackList : List<Snack>
    {
        public SnackList() { } //בנאי ברירת מחדל
        public SnackList(IEnumerable<Snack> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public SnackList(IEnumerable<BaseEntity> list) :
            base(list.Cast<Snack>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}
