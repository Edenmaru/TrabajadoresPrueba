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

        //Vista Principal
        public IActionResult Index()
        {
           List<Trabajador> lista = (List<Trabajador>)listaTrabajadores();
           return View(lista);
        }

        //Vista Parcial (Modal)
        //Creacion de trabajadores
        [HttpGet]
        public IActionResult Crear()
        {
            Trabajadores trabajador = new Trabajadores();        
            ViewBag.Departamentos = new SelectList(listaDepartamentos(), "Id", "NombreDepartamento");
            return PartialView("Crear", trabajador);
        }

        [HttpPost]public IActionResult Crear(Trabajadores trabajador)
        {
            ViewBag.Departamentos = new SelectList(listaDepartamentos(), "Id", "NombreDepartamento");
            using (var db = new TrabajadoresPruebaContext())
            {
                if (ModelState.IsValid)
                {
                    db.Trabajadores.Add(trabajador);
                    db.SaveChanges();      
                }
                
            }
            return PartialView("Crear", trabajador);

        }

        //Edicion de la información de trabajadores
        public IActionResult Editar(int id)
        {
            Trabajadores trabajador = new Trabajadores();
            ViewBag.Departamentos = new SelectList(listaDepartamentos(), "Id", "NombreDepartamento");
            using ( var db = new TrabajadoresPruebaContext())
            {
                trabajador = db.Trabajadores.Where(x => x.Id == id).FirstOrDefault();
            }
            return PartialView("Editar", trabajador);
        }

        [HttpPost]
        public IActionResult Editar(Trabajadores trabajador)
        {
            ViewBag.Departamentos = new SelectList(listaDepartamentos(), "Id", "NombreDepartamento");
            if (ModelState.IsValid)
            {

                using (var db = new TrabajadoresPruebaContext())
                {
                    db.Trabajadores.Update(trabajador);
                    db.SaveChanges();
                }
            }
            return PartialView("Editar", trabajador);
        }

        //Eliminacion de los trabajadores 
        public IActionResult Eliminar(int id)
        {
            Trabajadores trabajador = new Trabajadores();
            using(var db = new TrabajadoresPruebaContext())
            {
                trabajador = db.Trabajadores.Where(x => x.Id == id).FirstOrDefault();
            }
            return PartialView("Eliminar",trabajador);
        }

        [HttpPost]
        public IActionResult Eliminar (Trabajadores trabajador)
        {
            Trabajadores t = new Trabajadores();
            using (var db = new TrabajadoresPruebaContext())
            {
                t = db.Trabajadores.Where(x => x.Id == trabajador.Id).FirstOrDefault();
                db.Trabajadores.Remove(t);
                db.SaveChanges();
            }
            return PartialView("Eliminar",t);
        }

        //JSON para llenar los dropdown de Provincia y Distrito segun Departamento y Provincia respectivamente
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
