using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndocrinRegistr.Models
{
    public partial class CaseRecord
    {
        [Key]
        public int CaseRecordId { get; set; }

        [Required, Display(Name = "Диагноз")]
        public short DiagId { get; set; }

        [Display(Name = "Диагноз")]
        public Diag Diag { get; set; }

        [Display(Name = "Врач")]
        public short? DoctorsId { get; set; }

        [Display(Name = "Врач")]
        public Doctors Doctors { get; set; }

        public List<LabCase> LabCases { get; set; }

        [Required, Display(Name = "ФИО")]
        public string Fio { get; set; }

        [DataType(DataType.Date), Display(Name = "Дата рождения")]
        public DateTime? DateBirth { get; set; }

        [Required, Display(Name = "Пол")]
        public string Sex { get; set; }

        [Display(Name = "Контакты")]
        public string Contacts { get; set; }

        [Display(Name = "Адрес")]
        public string Adds { get; set; }

        [Display(Name = "Место работы")]
        public string Job { get; set; }

        [Display(Name = "Дополнение диагноза")]
        public string CompDiag { get; set; }

        [Display(Name = "История болезни")]
        public int? NumCase { get; set; }

        [Display(Name = "Год выявления заболевания")]
        public short? DetectCaseY { get; set; }

        [Display(Name = "Год выявления образования")]
        public short? DetectFormationY { get; set; }

        [Display(Name = "Подробности выявления")]
        public string DetectDetails { get; set; }

        [Display(Name = "Жалобы")]
        public string Complaints { get; set; }

        [Display(Name = "Ожирение/избыточный вес")]
        public string Obesity { get; set; }

        [Display(Name = "Нарушение углеводного обмена")]
        public string DisorderCarbo { get; set; }

        [Display(Name = "Артериальная гипертензия")]
        public string ArterHypert { get; set; }

        [Display(Name = "Наруш. фосфорно-кальц. обмена")]
        public string DisorderPcm { get; set; }

        [Display(Name = "Визуализация")]
        public string Visual { get; set; }

        [Display(Name = "ИГХ")]
        public string Igh { get; set; }

        [Display(Name = "Оперативное лечение")]
        public string Operation { get; set; }

        [Display(Name = "Послеоперационный период")]
        public string Postoper { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkNpvaA { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkPnvA { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkLnvA { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkNpvbA { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkNpvaK { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkPnvK { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkLnvK { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F1}"), Column(TypeName = "decimal(4,1)"), Range(0, 999.9)]
        public decimal? SvzkNpvbK { get; set; }

        public CaseRecord()
        {
            DiagId = 1;
            Fio = "";
            Sex = "";
        }
    }
}
