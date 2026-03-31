using Microsoft.Data.SqlClient;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.BLL.Services;
using ProjectLibrary.DAL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectLibrary.ASPMVC.Handlers;


namespace ProjectLibrary.ASPMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddScoped<UserSessionManager>();
            builder.Services.AddScoped<SqlConnection>(options =>
               new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectManager;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;"));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddScoped<ASPMVC.Handlers.UserSessionManager>();
            builder.Services.AddScoped<IEmployeeRepository<DAL.Entities.Employee>, DAL.Services.EmployeeService>();
            builder.Services.AddScoped<BLL.Services.EmployeeService>();
            builder.Services.AddScoped<IPostRepository<DAL.Entities.Post>, DAL.Services.PostService>();
            builder.Services.AddScoped<BLL.Services.PostService>();
            builder.Services.AddScoped<IProjectRepository<DAL.Entities.Project>, DAL.Services.ProjectService>();
            builder.Services.AddScoped<BLL.Services.ProjectService>();
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();
            builder.Services.AddScoped<BLL.Services.AuthService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/Logout";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
