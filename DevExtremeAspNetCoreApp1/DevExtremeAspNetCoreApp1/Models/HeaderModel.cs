using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreApp1.Models
{
    public class HeaderModel
    {
        [FromHeader]
        public string Host { get; set; }
        [FromHeader]
        public string Accept { get; set; }
        [FromHeader(Name = "User-Agent")]
        public string UserAgent { get; set; }
    }
}
