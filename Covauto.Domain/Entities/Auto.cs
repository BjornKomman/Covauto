using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Domain.Entities
{
    public class Auto
    {
        public int Id { get; set; } 
        public string NaamAuto { get; set; }
        public int Kilometerstand { get; set; }
        public bool Beschikbaarheid { get; set; }
        public int PublicatieJaar { get; set; }
    }

}
