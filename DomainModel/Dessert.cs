using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Dessert : Product
    {
        public double Millimeter { get; set; }
        public bool IsFrozen { get; set; }
    }
}
