using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using Timepiece.Repositories.Models;
using Timepiece.Repositories.UnitOfWork;
using Timepiece.Services.InternalService.IServices.IAccountServies;
using Timepiece.Services.InternalService.Services.AccountServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//GIÚP ENUM HIỆN LÊN DẠNG CHUỖI
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;

    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db context
builder.Services.AddDbContext<VintageWatchDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Đăng kí Repository

// Đăng ký Services 
builder.Services.AddScoped<IAccountService, AccountService>();

//Đăng kí UnitOfWork
builder.Services.AddScoped<UnitOfWork>();

// Cấu hình Swagger với thông tin chi tiết và XML comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Timepiece Vintage Watch API",
        Version = "V11",
        Description = "API quản lý đồng hồ cổ điển"
    });

    // Đường dẫn tới file XML documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
