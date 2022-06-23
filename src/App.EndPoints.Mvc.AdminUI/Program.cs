using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Permission.Contarcts.Repositories;
using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Services.BaseData;
using App.Domain.Services.Permission;
using App.Domain.Services.Product;
using App.Infrastructures.Database.Repos.Ef.BaseData;
using App.Infrastructures.Database.Repos.Ef.Permission;
using App.Infrastructures.Database.Repos.Ef.Product;
using App.Infrastructures.Database.SqlServer.Data;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=MASOUD;Initial Catalog=DotNetShopDb;Persist Security Info=True;User ID=sa;Password=25915491");
});





builder.Services.AddScoped<IProductAppService, ProductAppService>();

#region BaseData
builder.Services.AddScoped<IBaseDataAppService, BaseDataAppService>();
builder.Services.AddScoped<IBaseDataService, BaseDataService>();
builder.Services.AddScoped<IBaseDataCommandRepository, BaseDataCommandRepository>();
builder.Services.AddScoped<IBaseDataQueryRepository, BaseDataQueryRepository>();
#endregion BaseData

#region Brand
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
#endregion Brand

#region Color
builder.Services.AddScoped<IColorAppService, ColorAppService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
#endregion Color

#region Category
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
#endregion Category

#region ProductModel
builder.Services.AddScoped<IProductModelAppService, ProductModelAppService>();
builder.Services.AddScoped<IProductModelService, ProductModelService>();
builder.Services.AddScoped<IProductModelCommandRepository, ProductModelCommandRepository>();
builder.Services.AddScoped<IProductModelQueryRepository, ProductModelQueryRepository>();
#endregion ProductModel


#region Permission
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
#endregion Permission



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
