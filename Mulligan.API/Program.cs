using Microsoft.EntityFrameworkCore;
using Mulligan.API.BusinessServices;
using Mulligan.API.Data;
using Mulligan.API.RepositoryServices;
using Mulligan.API.RepositoryServices.RepositoryClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGolfCourseBusinessService, GolfCourseBusinessService>();
builder.Services.AddScoped<IGolfCourseRepoService, GolfCourseRepoService>();
builder.Services.AddScoped<IGolfCourseRepoClient, GolfCourseRepoClient>();
builder.Services.AddScoped<IPostBusinessService, PostBusinessService>();
builder.Services.AddScoped<IPostRepoService, PostRepoService>();
builder.Services.AddScoped<IPostRepoClient, PostRepoClient>();
builder.Services.AddScoped<IScoreBusinessService, ScoreBusinessService>();
builder.Services.AddScoped<IScoreRepoService, ScoreRepoService>();
builder.Services.AddScoped<IScoreRepoClient, ScoreRepoClient>();
builder.Services.AddScoped<IUserBusinessService, UserBusinessService>();
builder.Services.AddScoped<IUserRepoService, UserRepoService>();
builder.Services.AddScoped<IUserRepoClient, UserRepoClient>();

builder.Services.AddDbContext<MulliganDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MulliganLocalConnectionString"));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("AllowAngularOrigins");

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
