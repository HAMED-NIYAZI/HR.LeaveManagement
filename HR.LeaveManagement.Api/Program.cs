using HR.LeaveManagement.Application;
using HR.LeaveManagement.infrastructure;
using HR.LeaveManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
//اضافه کردن کانفیگ هایی که نوشته بودیم
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1",new OpenApiInfo { Title="HR LeaveManagement Api",Version="v1"});
});



//اضافه کردن Cors policy
//برای اینکه هر ردخواستی از بیرون دریافت شود
// how the api allows other clients to interact with it
// this one is open . doesnt have any restriction
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
   // app.UseSwagger();
   // app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","HR.LeaveManagement.Api v1"));
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.LeaveManagement.Api v1"));

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
