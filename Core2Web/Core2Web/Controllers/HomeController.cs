using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core2Web.Models;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Core2Web.Data;
using System.ComponentModel.DataAnnotations;

namespace Core2Web.Controllers
{
    public class HomeController : Controller
    {
        NorthwindContext _northwindContext;
        public HomeController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public IActionResult Index()
        {
            var model = _northwindContext.Orders.Take(10).ToList();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public object GetDatasource(DataSourceLoadOptions loadOptions)
        {
            var model =  _northwindContext.Orders.GroupJoin(_northwindContext.OrderDetails,o => o.OrderID,d => d.OrderID, (o,d) => 
                new OrderViewModel
                {
                    OrderId = o.OrderID,
                    CustomerID = o.CustomerID,
                    EmployeeID = o.EmployeeID,
                    OrderDate = o.OrderDate,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    //ProductID = d.FirstOrDefault().ProductID,
                    UnitPrice = d.FirstOrDefault().UnitPrice,
                    Quantity = d.FirstOrDefault().Quantity
                }
          );
            return DataSourceLoader.Load(model, loadOptions);
        }

        public IActionResult GetAll()
        {
            return Content("!!!!!!!!!!!!!");
            //return _northwindContext.Orders.Take(100).ToList().Join(_northwindContext.OrderDetails, o => o.OrderId, d => d.OrderId, (o, d) =>
            //      new OrderViewModel
            //      {
            //          OrderId = o.OrderId,
            //          CustomerID = o.CustomerID,
            //          EmployeeID = o.EmployeeID,
            //          OrderDate = o.OrderDate,
            //          ShipName = o.ShipName,
            //          ShipAddress = o.ShipAddress,
            //          ShipCity = o.ShipCity,
            //          ProductID = d.ProductID,
            //          UnitPrice = d.UnitPrice,
            //          Quantity = d.Quantity
            //      });
        }
    }
}
