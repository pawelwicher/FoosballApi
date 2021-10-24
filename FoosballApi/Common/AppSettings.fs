namespace FoosballApi.Configuration

open Microsoft.Extensions.Configuration

module AppSettings =

    let connectionString =
        ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("FoosballApiDb")