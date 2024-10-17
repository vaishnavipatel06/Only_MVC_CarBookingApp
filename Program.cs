using CarBookingApp.IServices;
using CarBookingApp.Services;

namespace Only_MVC_CarBookingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            //builder.Services.AddHttpClient<IBookService, BookService>(client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:7045/api/Bookings"); // Replace with your API's base address
            //});

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();
            Configure(app);

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add Controllers with Views (MVC)
            services.AddControllersWithViews();

            // Configure HttpClient for IBookService
            services.AddHttpClient<IBookService, BookService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7045/api/Bookings"); // Replace with your API base address
            });
        }

        // Middleware Configuration
        public static void Configure(WebApplication app)
        {
            // Exception handling
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // HSTS for production
            }

            // Security & static files
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Routing configuration
            app.UseRouting();
            app.UseAuthorization();

            // Endpoint mapping for MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Run the application
            app.Run();
        }
    }
}
