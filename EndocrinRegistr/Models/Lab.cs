using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndocrinRegistr.Models
{
    public partial class Lab
    {
        public short LabId { get; set; }

        public bool Deleted { get; set; }

        [Required(ErrorMessage = "Не введено лабораторное исследование")]
        [Display(Name = "Лабораторное исследование")]
        public string LabName { get; set; }
    }
}
