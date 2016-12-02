using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    class AlunoController
    {
        [HttpGet]
        public ActionResult index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Action()
        {
            return View();
        }
    }
}
