using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;

namespace Sample.Controllers
{
  [ODataRoute("odata/Products")]
  public class ProductsController : Controller
  {
    private NorthwindContext context;

    public ProductsController(NorthwindContext context)
    {
      this.context = context;
    }

    // GET api/values
    [HttpGet]
    [EnableQuery]
    public IEnumerable<Product> Get()
    {
      return this.context.Products;
    }

    // GET api/values/5
    [HttpGet("{productId}")]
      public IActionResult GetProduct(int productId)
      {
        return new ObjectResult(productId);
      }

    // POST api/values
    [HttpPost]
      public void Post([FromBody]string value)
      {
      }

    // PUT api/values/5
    [HttpPut("{id}")]
      public void Put(int id, [FromBody]string value)
      {
      }

    // DELETE api/values/5
    [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
  }
}
