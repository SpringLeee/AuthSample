using IdentitySample;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<MyDBContext>(x => x.UseInMemoryDatabase("MyDB"));

services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<MyDBContext>().AddDefaultTokenProviders();  

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
