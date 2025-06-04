using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Shared.DTO.Rit
{
    public class RitListItem
    {
        public int Id { get; set; }
        public string AutoNaam { get; set; } = string.Empty;
        public string GebruikerNaam { get; set; } = string.Empty;
        public DateTime Datum { get; set; }
    }
}

