﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_final_pro_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PerfilAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult CambiarContrasena()
        {
            return View();
        }
        public IActionResult Nuevo_Producto()
        {
            return View();
        }
        public IActionResult Detalle_Producto_Admin()
        {
            return View();
        }
    }
}