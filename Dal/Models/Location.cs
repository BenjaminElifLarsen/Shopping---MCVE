using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Location
    {
        public int LocationId { get; private set; }
        public string Name { get; private set; }
        public Ware Ware { get; private set; } //set it up in the context so it is added to the ware table
    }
}
