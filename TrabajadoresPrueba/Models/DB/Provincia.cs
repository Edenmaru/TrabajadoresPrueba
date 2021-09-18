using System;
using System.Collections.Generic;

#nullable disable

namespace TrabajadoresPrueba.Models.DB
{
    public partial class Provincia
    {
        public Provincia()
        {
            Distrito = new HashSet<Distrito>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int Id { get; set; }
        public int? IdDepartamento { get; set; }
        public string NombreProvincia { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
