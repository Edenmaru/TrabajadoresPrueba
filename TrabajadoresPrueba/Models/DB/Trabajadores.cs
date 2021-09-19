using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrabajadoresPrueba.Models.DB
{
    public partial class Trabajadores
    {
        public int Id { get; set; }
        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "Obligatorio")]
        public string TipoDocumento { get; set; }
        [Display(Name = "Nro Documento")]
        [Required(ErrorMessage = "Obligatorio")]
        public int? NroDocumento { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Obligatorio")]
        public string Nombres { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Obligatorio")]
        public string Sexo { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Obligatorio")]
        public int? IdDepartamento { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Obligatorio")]
        public int? IdProvincia { get; set; }
        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Obligatorio")]
        public int? IdDistrito { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
    }
}
