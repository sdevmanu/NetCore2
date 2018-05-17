using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NetCore2.Models;
using NetCore2.Repositories;
using Microsoft.AspNetCore.Http;

namespace NetCore2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //http://www.forevolve.com/en/articles/2017/08/14/design-patterns-web-api-service-and-repository-part-2/
            services.AddTransient<IItemService, ItemService>();
            //services.AddDbContext<TodoContext>(opt =>
            //    opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
        }
       

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.Run(async (context) => { await context.Response.WriteAsync("MVC Did not find anything"); });
        }
    }
}
