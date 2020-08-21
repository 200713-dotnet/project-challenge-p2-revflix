using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace RevFlix.Service
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(pol =>
        {
          pol.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
      });
      services.AddControllers();
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        {
          Version = "1.1",
          Title = "RevFlix Movie API"
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RevFlix Movie API v1");
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>           // global routing
      {
          endpoints.MapControllerRoute(
              name: "default",
              pattern: "/movie/{controller=imdbi}/{action=Get}");
      });
    }
  }
}
