using Stream_backend.Model;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); 
builder.Services.AddSingleton<IStreamerModel,StreamerModel>();
builder.Services.AddSingleton<IVideoModel,VideoModel>();
builder.Services.AddSingleton<IGamesModel,GamesModel>();

//mongodb services
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDB)));
builder.Services.AddSingleton<MongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();
