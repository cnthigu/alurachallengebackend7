using DepoimentosApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Desenvolvimento", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();           

builder.Services.AddControllers(); 

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseCors("Desenvolvimento");  

}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();              
    app.UseSwaggerUI();            
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
