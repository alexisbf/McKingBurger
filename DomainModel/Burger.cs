using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Burger : Product
    {
        public int Weight { get; set; }
        public int BeefWeight { get; set; }
    }
}
