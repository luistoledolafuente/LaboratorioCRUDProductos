using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LaboratorioCRUDProductos.Models
{
    public class ProductoModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 1000000, ErrorMessage = "El stock no puede ser negativo")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

    }
}