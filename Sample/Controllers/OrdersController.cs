using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;

namespace Sample.Controllers
{
  [ODataRoute("odata/Orders")]
  public class OrdersController : Controller
  {
    private NorthwindContext context;

    public OrdersController(NorthwindContext context)
    {
      this.context = context;
    }

    // GET api/values
    [HttpGet]
    [EnableQuery]
    public IEnumerable<Order> Get()
    {
      return this.context.Orders;
    }
  }
}
