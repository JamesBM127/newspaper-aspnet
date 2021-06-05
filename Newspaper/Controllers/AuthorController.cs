using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
