using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

namespace StringModificationApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigurationServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
          options.AddPolicy("MyPolicy", builder =>
          {
              builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
          });
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IWebHostEnvironment hostEnv)
    {

      var hostingEnvironment = (IWebHostEnvironment)env;

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseCors("MyPolicy");

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
      });
      RotativaConfiguration.Setup(env);
    }
  }
}