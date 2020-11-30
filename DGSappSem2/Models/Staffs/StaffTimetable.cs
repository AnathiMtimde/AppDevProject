using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DGSappSem2.Models.Staffs
{
    public class StaffTimetable
    {
        [Key]
        public int StaffTimetableId { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [Required(ErrorMessage = "Select a term")]
        [Display(Name = "Select a Term")]
        public string Term { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M1 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M2 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M3 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M4 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M5 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string M6 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T1 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T2 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T3 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T4 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T5 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string T6 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W1 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W2 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W3 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W4 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W5 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string W6 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th1 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th2 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th3 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th4 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th5 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string Th6 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F1 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F2 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F3 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F4 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F5 { get; set; }

        [Required(ErrorMessage = "Select a class")]
        public string F6 { get; set; }
    }
}