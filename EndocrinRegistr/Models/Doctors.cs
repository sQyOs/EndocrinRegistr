using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndocrinRegistr.Models
{
    public partial class Doctors
    {
        [Key]
        public short DoctorId { get; set; }

        [Required]
        [Display(Name ="ФИО врача")]
        public string Doctor { get; set; }

        public bool Deleted { get; set; }
    }
}
