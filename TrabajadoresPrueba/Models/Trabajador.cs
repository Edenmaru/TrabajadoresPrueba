using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public string nombreDepartamento { get; set; }
        public string nombreProvincia { get; set; }
        public string nombreDistrito { get; set; }
    }
}
