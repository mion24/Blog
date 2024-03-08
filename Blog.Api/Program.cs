using Blog.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();
builder.AddAccountContext();
builder.AddPostContext();
builder.AddMediator();
builder.Services.AddHttpContextAccessor();
//builder.WebHost.UseUrls("http://*:8080");

var app = builder.Build();
app.UseCors("_myAllowSpecificOrigins");

app.MapAccountEndpoints();
app.MapPostEndpoints();
app.UseCors();

app.Run();
