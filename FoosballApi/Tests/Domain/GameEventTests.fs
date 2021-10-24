namespace FoosballApi.Tests.Domain

open System
open Xunit
open FsUnit.Xunit

open FoosballApi.Domain

module GameEventTests =

    [<Fact>]
    let ``should create``() =
        let date = DateTime(2021, 10, 24)
        let score = GameScore.create 0 0 0 0
        let actual = GameEvent.create date GameCreated score

        let expected =
            { date = date
              eventType = GameCreated
              gameScore = GameScore.create 0 0 0 0 }

        actual |> should equal expected