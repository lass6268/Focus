using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Medarbejder
    {
        public string Name { get; set; }
        public int ID { get; set; }



        public Medarbejder(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
