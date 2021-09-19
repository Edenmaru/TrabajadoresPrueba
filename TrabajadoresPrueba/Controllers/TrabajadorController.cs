using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
