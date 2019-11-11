using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace locker_reading.Models
{
    public class Lecture
    {
        [Key]
        [Column(Order = 0)]
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Libro")]
        public Book Book { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [Display(Name = "¿En qué página vas?")]
        [Range(0, 2000, ErrorMessage = "Ingrese un número de páginas válido.")]
        public int Advance { get; set; }

        public int SelectedBookId { get; set; }

        [Display(Name = "¿Cuántas páginas leíste hoy?")]
        [Required]
        public int NumAdvance { get; set; }

        [Required]
        [Display(Name = "¿Finalizado?")]
        public bool Finished { get; set; }

        [Display(Name = "Breve reseña")]
        [DataType(DataType.MultilineText)]
        public string Review { get; set; }

        [NotMapped]
        public List<Book> UserBooks { get; set; }
    }
}