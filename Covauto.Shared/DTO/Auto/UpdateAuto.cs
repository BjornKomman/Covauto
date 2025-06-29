﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Covauto.Applicatie.DTO.Auto
{
    public class UpdateAuto
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("naamAuto")]
        public string naamAuto { get; set; }

        [Required]
        [JsonPropertyName("kilometerstand")]
        public int kilometerstand { get; set; }

        [Required]
        [JsonPropertyName("beschikbaarheid")]
        public bool beschikbaarheid { get; set; }
    }
}