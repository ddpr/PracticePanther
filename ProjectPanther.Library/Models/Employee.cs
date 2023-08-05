using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Models
{
    public class Employee
    {
        public String Name { get; set; }
        public decimal Rate { get; set; }
        public int Id { get; set; }


        public override string ToString()
        {
            return $"-{Name}\n";
        }//end of ToString() override
    }
}
