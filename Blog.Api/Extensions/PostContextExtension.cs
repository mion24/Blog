using MediatR;

namespace Blog.Api.Extensions
{
    public static class PostContextExtension
    {
        public static void AddPostContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<
                Core.Contexts.PostContext.UseCases.Create.Contracts.IRepository,
                Infra.Contexts.PostContext.UseCases.Create.Repository
                >();

            builder.Services.AddTransient<
              Core.Contexts.PostContext.UseCases.GetAll.Contracts.IRepository,
              Infra.Contexts.PostContext.UseCases.GetAll.Repository
              >();

            builder.Services.AddTransient<
             Core.Contexts.PostContext.UseCases.Delete.Contracts.IRepository,
             Infra.Contexts.PostContext.UseCases.Delete.Repository
             >();

            builder.Services.AddTransient<
            Core.Contexts.PostContext.UseCases.Put.Contracts.IRepository,
            Infra.Contexts.PostContext.UseCases.Put.Repository
            >();
        }

        public static void MapPostEndpoints(this WebApplication app)
        {
            #region create
            app.MapPost("v1/new-post", async (
            Blog.Core.Contexts.PostContext.UseCases.Create.Request request,
            IRequestHandler<
                Blog.Core.Contexts.PostContext.UseCases.Create.Request,
                Blog.Core.Contexts.PostContext.UseCases.Create.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"/v1/posts/{result.Data?.id}", result)
                    : Results.Json(result, statusCode: result.Status);
            }).RequireAuthorization();
            #endregion

            #region getall
            app.MapGet("v1/posts", async (
            IRequestHandler<
                Blog.Core.Contexts.PostContext.UseCases.GetAll.Request,
                Blog.Core.Contexts.PostContext.UseCases.GetAll.Response> handler) =>
            {
                var result = await handler.Handle(new Core.Contexts.PostContext.UseCases.GetAll.Request(), new CancellationToken());
                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            }).AllowAnonymous();
            #endregion

            #region delete
            app.MapPost("v1/delete-post", async (
            Blog.Core.Contexts.PostContext.UseCases.Delete.Request request,
             IRequestHandler<
                 Blog.Core.Contexts.PostContext.UseCases.Delete.Request,
                 Blog.Core.Contexts.PostContext.UseCases.Delete.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            }).RequireAuthorization();
            #endregion

            #region put
            app.MapPut("v1/put-post", async (
             Blog.Core.Contexts.PostContext.UseCases.Put.Request request,
             IRequestHandler<
                 Blog.Core.Contexts.PostContext.UseCases.Put.Request,
                 Blog.Core.Contexts.PostContext.UseCases.Put.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            }).RequireAuthorization();
            #endregion
        }
    }
}
