using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebScrapper.Application.Mappings;
using WebScrapper.Application.Queries;
using WebScrapper.Core.Services;
using WebScrapper.Data.Data;
using WebScrapper.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

//var  myAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigins
//        builder =>
//        {
//            builder.WithOrigins("*");
//        });
//});

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsPolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("sql");
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<ISearchHistoryService, SearchHistoryService>();
builder.Services.AddTransient<ISearchHistoryDataService, SearchHistoryRepository>();
builder.Services.AddTransient<ISearchEngineDataService, SearchEngineRepository>();

builder.Services.AddMediatR(typeof(GetSearchEnginesQuery));
builder.Services.AddMediatR(typeof(GetSearchRankingsQuery));
builder.Services.AddMediatR(typeof(GetSearchResultsHistoryQuery));
ConfigureAutoMapper(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureAutoMapper(IServiceCollection services)
{
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile<ApplicationMappings>();
    });

    IMapper mapper = mappingConfig.CreateMapper();
    services.AddSingleton(mapper);
}
