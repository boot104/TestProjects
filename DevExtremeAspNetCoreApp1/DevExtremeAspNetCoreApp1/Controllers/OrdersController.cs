using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevExtremeAspNetCoreApp1.Controllers {

    [Route("api/[controller]")]
    public class OrdersController : Controller {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {

            Startup.CoreLoggerFactory.CreateLogger("LOGGER").LogInformation("LOAD SALES");
            var model = SampleData.Orders;
            return DataSourceLoader.Load(model, loadOptions);
        }

    }
}