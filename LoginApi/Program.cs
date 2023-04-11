using LoginApi.Datas;
using LoginApi.IRepositories;
using LoginApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Configure Services
builder.Services.AddCors(options => { options.AddPolicy("corapp", a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());});
#endregion
#region Configure Database
var ConnectionStrings = builder.Configuration.GetConnectionString("Defaultconnections");
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer("server=DESKTOP-30IUE2U;database=Exl_Udt_CRM;user=sa;password=Exalca@123;"));
#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
