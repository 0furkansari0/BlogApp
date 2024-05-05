using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("Sql_connection");
    options.UseSqlite(connectionString);

    //var version = new MySqlServerVersion(new Version(10,3,0));
    //var version = ServerVersion.AutoDetect(connectionString);
    //options.UseMySql(connectionString, version);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath ="/Users/Login");

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


SeedData.TestVerileriniDoldur(app);


app.MapControllerRoute(
    name:"post_details",
    pattern:"posts/details/{url}",
    defaults: new {controller ="Posts", action ="Details"}
);

app.MapControllerRoute(
    name:"posts_by_tag",
    pattern:"posts/tag/{tag}",
    defaults: new {controller ="Posts", action ="Index"}
);

app.MapControllerRoute(
    name:"user_profile",
    pattern:"profile/{username}",
    defaults: new {controller ="Users", action ="Profile"}
);


app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Posts}/{action=Index}/{id?}"
);



app.Run();