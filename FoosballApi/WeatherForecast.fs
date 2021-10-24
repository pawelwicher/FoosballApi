namespace FoosballApi

open System

module Foo =
    let x = 1

    let foo = nameof x

type WeatherForecast =
    { Date: DateTime
      TemperatureC: int
      Summary: string }

    member this.TemperatureF =
        32.0 + (float this.TemperatureC / 0.5556)
