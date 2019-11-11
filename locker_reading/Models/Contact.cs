using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace locker_reading.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Mensaje")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; } = DateTime.Now;

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Ip { get; set; }
    }
}