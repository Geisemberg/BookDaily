//using BookDaily.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BookDailyDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDailyContext"));
//});

//var allowOrigins = "*";

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: allowOrigins,
//        policy =>
//        {
//            policy.AllowAnyOrigin()
//                  .AllowAnyMethod();


//        });

//});

////hasta aca

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(allowOrigins);

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



//using BookDaily.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BookDailyDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDailyContext"));
//});

//var allowSpecificOrigins = "allowSpecificOrigins";

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: allowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:4200") // Especifica los orígenes permitidos
//                  .AllowAnyMethod()
//                  .AllowAnyHeader()
//                  .AllowCredentials(); // Permitir credenciales para WebSocket
//        });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(allowSpecificOrigins);

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


//using BookDaily.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BookDailyDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDailyContext"));
//});

//var allowSpecificOrigins = "allowSpecificOrigins";

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: allowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:4200") // Especifica los orígenes permitidos
//                  .AllowAnyMethod()
//                  .AllowAnyHeader()
//                  .AllowCredentials(); // Permitir credenciales para WebSocket
//        });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(allowSpecificOrigins);

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



//using BookDaily.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BookDailyDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDailyContext"));
//});

//var allowSpecificOrigins = "allowSpecificOrigins";

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: allowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:4200")
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(allowSpecificOrigins);

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using BookDaily.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookDailyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDailyContext"));
});

var allowSpecificOrigins = "allowSpecificOrigins";

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

