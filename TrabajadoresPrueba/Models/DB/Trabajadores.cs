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
        [Required(AllowEmptyStrings =false ,ErrorMessage = "Obligatorio")]
        public string TipoDocumento { get; set; }
        [Display(Name = "Nro Documento")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Solo permite 8 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar el nro de documento")]
        public int? NroDocumento { get; set; }
        [Display(Name = "Nombres")]
        [RegularExpression(@"^[\W\w ]{1,500}$", ErrorMessage = "Solo permite 500 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar sus nombres")]
        public string Nombres { get; set; }
        [Display(Name = "Sexo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obligatorio")]
        public string Sexo { get; set; }
        [Display(Name = "Departamento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obligatorio")]
        public int? IdDepartamento { get; set; }
        [Display(Name = "Provincia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obligatorio")]
        public int? IdProvincia { get; set; }
        [Display(Name = "Distrito")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obligatorio")]
        public int? IdDistrito { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
    }
}
