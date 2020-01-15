using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndocrinRegistr.Models
{
    public partial class LabCase
    {
        [HiddenInput]
        public int LabCaseId { get; set; }

        [Required]
        [HiddenInput]
        public int CaseRecordId { get; set; }

        public CaseRecord CaseRecord { get; set; }

        [Required]
        [Display(Name = "Лабораторное исследование")]
        public short LabId { get; set; }

        public Lab Lab { get; set; }

        public short DetectYear { get; set; }

        public string Comment { get; set; }

    }
}
