using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Applicatie.DTO.Auto
{
    public class AutoListItem
    {
        public int Id { get; set; }
        public string naamAuto { get; set; }
        public int kilometerstand { get; set; }
        public string startAdres { get; set; }
        public string eindAdres { get; set; }
        public bool beschikbaarheid { get; set; }
    
    }
}
