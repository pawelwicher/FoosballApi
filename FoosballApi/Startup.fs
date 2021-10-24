namespace FoosballApi

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.OpenApi.Models

open FoosballApi.DataAccess
open FoosballApi.Application.Service

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    member _.ConfigureServices(services: IServiceCollection) =
        let info = OpenApiInfo()
        info.Title <- "FoosballApi"
        info.Version <- "v1"
        services.AddSwaggerGen(fun config -> config.SwaggerDoc("v1", OpenApiInfo())) |> ignore

        services.AddScoped<IGameQueryRepository, GameRepository>() |> ignore
        services.AddScoped<IGameCommandRepository, GameRepository>() |> ignore
        services.AddScoped<IGameAppService, GameAppService>() |> ignore

        services.AddControllers() |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        app.UseHttpsRedirection()
           .UseSwagger()
           .UseSwaggerUI(fun config -> config.SwaggerEndpoint("/swagger/v1/swagger.json", "FoosballApi v1"))
           .UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints -> endpoints.MapControllers() |> ignore) |> ignore