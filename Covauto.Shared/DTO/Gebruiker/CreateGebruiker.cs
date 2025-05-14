using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Covauto.Applicatie.DTO.Gebruiker
{
    public class CreateGebruiker
    {
        [Required]
        [JsonPropertyName("naam")]
        public string Naam { get; set; }
    }
}