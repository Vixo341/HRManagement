using System.Reflection;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HRManagement.BlazorUI;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Services;
using HRManagement.BlazorUI.Services.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IClient, Client>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7021");
});

builder.Services.AddBlazoredToast();


builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
await builder.Build().RunAsync();