using Microsoft.AspNetCore.Builder;
using RoutingImplementation.Models.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("AlphabetWithNumericOurOwnName", typeof(AlphabetWithNumericConstraint));
}
);

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

//app.MapControllerRoute(
//    name: "ChatGPTSearch",
//    pattern: "ChatGPT/Browse",
//    defaults: new {controller="ChatGPT", action="Search"}
//    );

//app.MapControllerRoute(
//    name: "ChatGPTInfo",
//    pattern: "InfoAboutChatGPT/{version:int}",
//    defaults:new {controller= "ChatGPT", action = "InfoAboutChatGPT" }
//    );

app.MapControllerRoute(
    name: "ControllerWithMethodOnly",
    pattern: "{controller}/{action}"
    );

app.MapControllerRoute(
    name: "ControllerWithMethodAndParams",
    pattern: "{controller}/{action}/{version:AlphabetWithNumericOurOwnName}",
    defaults: new {controller="ChatGPT",action="InfoAboutChatGPT"}
    );



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
