using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {

        public String Name { get; set; }
        public int ID { get; set; }
        public int TotalCurrent { get; set; }
        public int AvgCurrent { get; set; }

        public Employee(string _name,int _id)
        {
            Name = _name;
            ID = _id;

        }
    }
}
