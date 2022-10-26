
// var builder = WebApplication.CreateBuilder(args);
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var myIp = GetIPAddress();
Console.WriteLine($"my ip: {myIp}");

builder.UseUrls(new string[] {url});

var app = builder.Build();

app.Run();

// app.MapGet("/", () => $"Hello {target}!");

// app.Run(url);

static string GetIPAddress()  
{  
    String address = "";  
    WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");  
    using (WebResponse response = request.GetResponse())  
     using (StreamReader stream = new StreamReader(response.GetResponseStream()))  
     {  
        address = stream.ReadToEnd();  
     }  
  
     int first = address.IndexOf("Address: ") + 9;  
     int last = address.LastIndexOf("</body>");  
     address = address.Substring(first, last - first);  
  
     return address;  
}  