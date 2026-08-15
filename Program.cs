using DevExpress.Blazor;
using UX.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);

var app = builder.Build();

string AppID = builder.Configuration["SamanSet:SamanApp:AppID"];
string ServerName = builder.Configuration["SamanSet:SamanApp:ServerName"];
DAL.CSet.SetCon(ServerName, AppID);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


//using DevExpress.Blazor;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.Extensions.Configuration;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//builder.Services.AddScoped<ProtectedSessionStorage>();

//builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);

//builder.Services.AddLocalization();

//var app = builder.Build();

//string AppID = builder.Configuration["SamanSet:SamanApp:AppID"];
//string ServerName = builder.Configuration["SamanSet:SamanApp:ServerName"];
//DAL.CSet.SetCon(ServerName, AppID);


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();


//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//app.MapControllers();
//app.Run();