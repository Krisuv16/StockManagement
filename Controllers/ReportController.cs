using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //This Action is responsible for displaying Product Stocks
        /*[Authorize(Roles = "")]*/
        [Authorize]
        public IActionResult ProductStockViewModel([FromQuery]string name ="")
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if(name == "")
                {
                    command.CommandText = "SELECT p.ProductID as ProductID, p.ProductName as ProductName, ps.Quantity from ProductModel p inner join StockModel ps on p.ProductID=ps.ProductId";
                }
                else
                {
                    command.CommandText = "SELECT p.ProductID as ProductID, p.ProductName as ProductName, ps.Quantity from ProductModel p inner join StockModel ps on p.ProductID=ps.ProductId where p.ProductName LIKE '%" + name + "%'";
                }

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    ProductStockViewModel data;
                    while (result.Read())
                    {
                        data = new ProductStockViewModel();
                        data.ProductID = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
                return View(lstData.OrderBy(x => x.ProductName));
            }
        }
/*        public ActionResult ProductSearch(string productname)
        {
            {
                var data = _context.StockModel.Include("ProductName").Include("Quantity").Where(x => x.PID.ProductName.Contains(productname) || productname == null).ToList();
                return View(data);
            }
        }*/

    }
}
