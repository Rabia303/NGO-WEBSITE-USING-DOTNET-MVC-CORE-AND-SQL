using GIVE_AID.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//var cs = "Server=DESKTOP-QDLC66A\\MSSQLSERVER_2019;Initial Catalog=NGOHub;User ID=sa;Password=aptech;TrustServerCertificate=True";
var cs = "Server=localhost;Initial Catalog=NGOHub;User ID=sa;Password=123;TrustServerCertificate=True";
builder.Services.AddDbContext<ngoDbContext>(op => op.UseSqlServer(cs));
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
