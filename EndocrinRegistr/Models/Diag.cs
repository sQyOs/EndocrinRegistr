using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndocrinRegistr.Models
{
    public partial class Diag
    {
        public short DiagId { get; set; }

        [Required(ErrorMessage = "Не введено название диагноза")]
        [Display(Name = "Диагноз")]
        public string NameDiag { get; set; }
        
        public bool Deleted { get; set; }
    }
}
