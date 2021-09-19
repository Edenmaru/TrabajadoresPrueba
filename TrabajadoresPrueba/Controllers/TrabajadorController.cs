using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajadoresPrueba.Models.DB;
using TrabajadoresPrueba.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadorController : Controller
    {
        //Conexion para el listado de trabajadores
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
                reg.Id =dr.GetInt32(0);
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

        //Listas usando EFCore
        IEnumerable<Departamento> listaDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();
            using (var db = new TrabajadoresPruebaContext())
            {
                lista = db.Departamento.ToList();
            }
            return lista;
        }

        IEnumerable<Provincia> listaProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            using (var db = new TrabajadoresPruebaContext())
            {
                lista = db.Provincia.ToList();
            }
            return lista;
        }

        IEnumerable<Distrito> listaDistritos()
        {
            List<Distrito> lista = new List<Distrito>();
            using (var db = new TrabajadoresPruebaContext())
            {
                lista = db.Distrito.ToList();
            }
            return lista;
        }

        //Vistas
        public IActionResult Index()
        {
           List<Trabajador> lista = (List<Trabajador>)listaTrabajadores();
           return View(lista);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            Trabajadores t = new Trabajadores();        
            ViewBag.Departamentos = new SelectList(listaDepartamentos(), "Id", "NombreDepartamento");
            return PartialView("Crear", t);
        }

        [HttpPost]public IActionResult Crear(Trabajadores trabajadores)
        {
            using (var db = new TrabajadoresPruebaContext())
            {
                if (ModelState.IsValid)
                {
                    db.Trabajadores.Add(trabajadores);
                    db.SaveChanges();      
                }
                
            }
            return PartialView("Crear", trabajadores);

        }

        public JsonResult CargarProvincia(int id)
        {
            var provincia = listaProvincias().Where(x => x.IdDepartamento == id).ToList();
            return Json(new SelectList(provincia, "Id", "NombreProvincia"));
        }

        public JsonResult CargarDistrito(int id)
        {
            var distrito = listaDistritos().Where(x => x.IdProvincia == id).ToList();
            return Json(new SelectList(distrito, "Id", "NombreDistrito"));
        }
    }
}
