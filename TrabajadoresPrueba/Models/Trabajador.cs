using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        [Display(Name ="Tipo Documento")]
        [Required(ErrorMessage ="Obligatorio")]
        public string TipoDocumento { get; set; }
        [Display(Name = "Nro Documento")]
        [Required(ErrorMessage = "Obligatorio")]
        public int NroDocumento { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Obligatorio")]
        public string Nombres { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Obligatorio")]
        public string Sexo { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Obligatorio")]
        public string nombreDepartamento { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Obligatorio")]
        public string nombreProvincia { get; set; }
        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Obligatorio")]
        public string nombreDistrito { get; set; }
    }
}
