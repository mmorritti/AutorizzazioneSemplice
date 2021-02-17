using AutorizzazioneSemplice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutorizzazioneSemplice.Controllers
{
    public class UserController : Controller
    {

        private MyContext _ctx;

        public UserController(IServiceProvider services)
        {
            _ctx = (MyContext)services.GetService(typeof(MyContext));
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var users = _ctx.Users.OrderBy(u => u.name).ToList();
                return View(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
