﻿
using System.ComponentModel.DataAnnotations;

namespace Simple301.Core.Models
{
    public class AddRedirectRequest
    {
        [Required]
        public string OldUrl { get; set; }
        [Required]
        public string NewUrl { get; set; }

        public string Notes { get; set; }
    }
}
