using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Domain
{
    public class Visit
    {
        public required Patient Patient { get; set; }
        public required Doctor Doctor { get; set; }
        public DateTime DateOfVisit { get; set; }
        public TimeOnly TimeOfVisit { get; set; }
        public int IdOfCabinet { get; set; }
        public bool IsAgain { get; set; }
    }
}
