using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace locker_reading.Models
{
    public class Book
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        //public ICollection<Lecture> Lectures { get; set; }

        [Required]
        [Display(Name = "Nombre del libro")]
        [StringLength(100)]
        public string BookName { get; set; }

        [Required]
        [Display(Name = "Autor")]
        [StringLength(100)]
        public string Author { get; set; }

        [Display(Name = "Breve Descripción")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0, 2000, ErrorMessage = "Ingrese un número de páginas válido.")]
        [Display(Name = "Número de páginas")]
        public int Pages { get; set; }

        public bool Finished { get; set; }
    }
}