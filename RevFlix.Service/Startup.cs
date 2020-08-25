using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using System;

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

      // --------- Leave these in here for Azure Secrets -----------
      // var client = new SecretClient(new Uri("https://revflixkeyvault.vault.azure.net/"), new DefaultAzureCredential());
      // KeyVaultSecret dbSecret = client.GetSecret("revflix-p2-azuredb");
      // services.AddDbContext<RevFlixDbContext>(options =>
      //     options.UseSqlServer(dbSecret.Value));
      services.AddDbContext<RevFlixDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));

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
          Version = "1.2",
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
      app.UseRouting();
      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RevFlix Movie API v1");
      });



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
