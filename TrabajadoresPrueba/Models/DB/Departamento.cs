using System;
using System.Collections.Generic;

#nullable disable

namespace TrabajadoresPrueba.Models.DB
{
    public partial class Departamento
    {
        public Departamento()
        {
            Provincia = new HashSet<Provincia>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int Id { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
