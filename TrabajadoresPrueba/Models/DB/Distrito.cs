using System;
using System.Collections.Generic;

#nullable disable

namespace TrabajadoresPrueba.Models.DB
{
    public partial class Distrito
    {
        public Distrito()
        {
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int Id { get; set; }
        public int? IdProvincia { get; set; }
        public string NombreDistrito { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
