var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", b =>
    b.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
