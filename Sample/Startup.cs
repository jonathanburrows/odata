using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Builder;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.OData.Edm;

namespace Sample
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddOData();

      // Add framework services.
      //      services.AddMvc().AddJsonOptions(options => {
      //         options.SerializerSettings.ContractResolver = new DefaultContractResolver();
      //        });

      //services.AddSingleton<NorthwindContext>();

      services.AddDbContext<NorthwindContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("NorthwindConnection")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      IAssemblyProvider provider = app.ApplicationServices.GetRequiredService<IAssemblyProvider>();
      IEdmModel model = GetEdmModel(provider);

      // Single
      app.UseMvc(builder => builder.MapODataRoute("odata", model));
    }

    private static IEdmModel GetEdmModel(IAssemblyProvider provider)
    {
      var builder = new ODataConventionModelBuilder(provider);
      builder.ContainerName = "NorthwindContext";

      builder.EntitySet<Product>("Products");

      builder.EntitySet<Order>("Orders");

      return builder.GetEdmModel();
    }
  }
}
