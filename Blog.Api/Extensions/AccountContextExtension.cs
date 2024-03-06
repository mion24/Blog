using MediatR;

namespace Blog.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region create
            builder.Services.AddTransient<
                Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
                Infra.Contexts.AccountContext.UseCases.Create.Repository
                >();
            #endregion

            #region auth
            builder.Services.AddTransient<
                Core.Contexts.AccountContext.UseCases.Authenticate.Contracts.IRepository,
                Infra.Contexts.AccountContext.UseCases.Authenticate.Repository
                >();
            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region create
            app.MapPost("v1/users", async (
            Core.Contexts.AccountContext.UseCases.Create.Request request,
            IRequestHandler<
                Core.Contexts.AccountContext.UseCases.Create.Request,
                Core.Contexts.AccountContext.UseCases.Create.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"/v1/users/{result.Data?.id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });
            #endregion

            #region auth
            app.MapPost("v1/authenticate", async (
            Core.Contexts.AccountContext.UseCases.Authenticate.Request request,
            IRequestHandler<
                Core.Contexts.AccountContext.UseCases.Authenticate.Request,
                Core.Contexts.AccountContext.UseCases.Authenticate.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());

                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);                
            });
            #endregion
        }
    }
}
