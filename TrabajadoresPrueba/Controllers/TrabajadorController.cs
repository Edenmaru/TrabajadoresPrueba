using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajadoresPrueba.Models.DB;
using TrabajadoresPrueba.Models;
using System.Data.SqlClient;
using System.Data;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadorController : Controller
    {
        SqlConnection cn = new SqlConnection("server=.;database=TrabajadoresPrueba;integrated security=true");

       

        //Listado de Trabajadores por StoreProcedure
        IEnumerable<Trabajador> listaTrabajadores()
        {
            List<Trabajador> temporal = new List<Trabajador>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TRABAJADORES", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Trabajador reg = new Trabajador();
                reg.Id = dr.GetInt32(0);
                reg.TipoDocumento = dr.GetString(1);
                reg.NroDocumento = dr.GetInt32(2);
                reg.Nombres = dr.GetString(3);
                reg.Sexo = dr.GetString(4);
                reg.nombreDepartamento = dr.GetString(5);
                reg.nombreProvincia = dr.GetString(6);
                reg.nombreDistrito = dr.GetString(7);
              
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();

            return temporal;
        }

        public IActionResult Index()
        {
            List<Trabajador> lista = (List<Trabajador>)listaTrabajadores();
            return View(lista);
        }
    }
}
