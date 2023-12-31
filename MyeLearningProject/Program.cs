using Business.Concrete;
using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Entity.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.UseDIExtensions();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code{0}");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
