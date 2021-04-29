using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserList : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new UsersContext())
            {
                return View(ctx.UserProfiles.ToList());
            }
        }
    }
}
