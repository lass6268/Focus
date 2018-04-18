using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Projektcheck
    {
        public string Makeprojekt(string _name, int _min, int _max, DateTime _start, DateTime _final)
        {
            
            if (_final > DateTime.Now)
            {
                return "Sorry, Final Date has past, try again";
            }
            else if (_final> _start)
            {
                return "Final Date is before Starting date";
            }
            else if (_min > _max && _max != 0)
            {
                return "Min is Bigger then Max";
            }
            else
            {
                Project projekt = new Project(_name, _min, _max, _start, _final);
                return "projekt has been made";
            }


           
        }

    }
}
