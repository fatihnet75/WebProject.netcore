﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class AkademisyenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}