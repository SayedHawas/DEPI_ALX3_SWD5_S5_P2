using Microsoft.EntityFrameworkCore;
using MVCDemoLab.Data;

namespace MVCDemoLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
            //builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
            builder.Services.AddSession(Config =>
            {
                Config.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            builder.Services.AddDbContext<MVCDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            //Middleware
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                 pattern: "{controller=Site}/{action=Index}/{id:int?}")
                //pattern: "{controller=Site}/{action=Index}/{id:int?}/{Name:alpha?}")
                //pattern: "{controller=Users}/{action=Login}/{id?}")
                //pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            #region Custom MiddleWare
            //app.Use(async (httpContext, next) =>
            //{
            //    //Logical Request 
            //    await httpContext.Response.WriteAsync("1) Write From MiddleWare  Request ....\n");
            //    //Call To Next Middleware
            //    await next.Invoke();

            //    //When RollBack As Response 
            //    await httpContext.Response.WriteAsync("5) Write From MiddleWare  Response  ....\n");
            //});

            //app.Use(async (httpContext, next) =>
            //{
            //    //Logical Request 
            //    await httpContext.Response.WriteAsync("2) Write From MiddleWare Request ....\n");
            //    //Call To Next Middleware
            //    await next();

            //    //When RollBack As Response 
            //    await httpContext.Response.WriteAsync("4) Write From MiddleWare Response ....\n");
            //});

            //app.Map("/Home/Index", apiApp =>
            //{
            //    apiApp.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("request Call the Controller Home And Action Index \n ");
            //        await next();
            //        await context.Response.WriteAsync(" Response Render Call the Controller Home And Action Index \n ");
            //    });
            //    apiApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync(" Execute RUN Response Render Call the Controller Home And Action Index \n ");
            //    });
            //});


            //app.Run(async (httpContext) =>
            //{
            //    //Logical Request 
            //    await httpContext.Response.WriteAsync("3)  RUN Write From MiddleWare Running ....\n");

            //});
            #endregion

            app.Run();
        }
    }
}
