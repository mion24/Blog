using Blog.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();
builder.AddAccountContext();
builder.AddPostContext();
builder.AddMediator();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapAccountEndpoints();
app.MapPostEndpoints();

app.Run();
