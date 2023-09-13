// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// public class Startup
// {
//     private readonly IWebHostEnvironment _env;

//     public Startup(IConfiguration configuration, IWebHostEnvironment env)
//     {
//         Configuration = configuration;
//         _env = env;
//     }

//     public IConfiguration Configuration { get; }

//     public void ConfigureServices(IServiceCollection services)
//     {
//         services.AddControllersWithViews();
//         // Configure other services as needed
//     }

//     public void Configure(IApplicationBuilder app)
//     {
//         if (_env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }
//         else
//         {
//             app.UseExceptionHandler("/Home/Error");
//             app.UseHsts();
//         }

//         app.UseHttpsRedirection();
//         app.UseStaticFiles();

//         app.UseRouting();

//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllerRoute(
//                 name: "default",
//                 pattern: "{controller=Home}/{action=Index}/{id?}");
//         });

//         // Other middleware configuration...
//     }
// }
