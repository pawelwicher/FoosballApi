namespace FoosballApi.Tests.Domain

open System
open Xunit
open FsUnit.Xunit

open FoosballApi.Domain

module GameTests =

    [<Fact>]
    let ``should create``() =
        let homeTeam = Team.create "team1"
        let awayTeam = Team.create "team2"
        let date = DateTime(2021, 10, 24)
        let score = GameScore.create 0 0 0 0
        let gameEvents = [GameEvent.create date GameCreated score]
        let actual = Game.create homeTeam awayTeam date score gameEvents

        let expected =
            { id = 0
              homeTeam = Team.create "team1"
              awayTeam = Team.create "team2"
              startDate = DateTime(2021, 10, 24)
              gameEvents = [GameEvent.create date GameCreated score] }

        actual |> should equal expected

    [<Fact>]
    let ``should start``() =
        let date = DateTime(2021, 10, 24)
        let score = GameScore.create 0 0 0 0
        let actual = Game.startGame "team1" "team2" date

        let expected =
            { id = 0
              homeTeam = Team.create "team1"
              awayTeam = Team.create "team2"
              startDate = DateTime(2021, 10, 24)
              gameEvents = [GameEvent.create date GameCreated score] }

        actual |> should equal expected

    [<Fact>]
    let ``should update``() =
        let homeTeam = Team.create "team1"
        let awayTeam = Team.create "team2"
        let date = DateTime(2021, 10, 24)
        let score = GameScore.create 1 1 9 9
        let gameEvents = seq { GameEvent.create date GameCreated score }
        let game = Game.create homeTeam awayTeam date score gameEvents
        let updatedGame = Game.update Home date game
        let actual = updatedGame.gameEvents |> Seq.head

        let expected = GameEvent.create date HomeWins (GameScore.create 2 1 0 0)

        actual |> should equal expected