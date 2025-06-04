using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Covauto.Shared.DTO.Rit
    {
        public class CreateRit
        {
            public int AutoId { get; set; }
            public int GebruikerId { get; set; }
            public string BeginAdres { get; set; } = string.Empty;
            public string EindAdres { get; set; } = string.Empty;
            public int BeginKmStand { get; set; }
            public int EindKmStand { get; set; }
            public DateTime Datum { get; set; } = DateTime.Now;
        }
    }

