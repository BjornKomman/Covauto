using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Shared.DTO.Rit
{
    public class RitDTO
    {
        public int Id { get; set; }
        public string AutoNaam { get; set; } = string.Empty;
        public string GebruikerNaam { get; set; } = string.Empty;
        public string BeginAdres { get; set; } = string.Empty;
        public string EindAdres { get; set; } = string.Empty;
        public int BeginKmStand { get; set; }
        public int EindKmStand { get; set; }
        public DateTime Datum { get; set; }
    }
}

