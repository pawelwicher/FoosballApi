namespace FoosballApi.Tests.Domain

open Xunit
open FsUnit.Xunit

open FoosballApi.Domain

module GameScoreTests =

    [<Fact>]
    let ``should create``() =
        let actual = GameScore.create 0 0 0 0

        let expected =
            { homeSets = 0
              awaySets = 0
              homeGoals = 0
              awayGoals = 0 }

        actual |> should equal expected


    [<Fact>]
    let ``should update``() =
        (GameScore.create 0 0 0 0) |> GameScore.update Home |> should equal ((GameScore.create 0 0 1 0), HomeScores)
        (GameScore.create 0 1 9 5) |> GameScore.update Home |> should equal ((GameScore.create 1 1 0 0), HomeScores)
        (GameScore.create 1 1 9 5) |> GameScore.update Home |> should equal ((GameScore.create 2 1 0 0), HomeWins)
        (GameScore.create 0 0 0 0) |> GameScore.update Away |> should equal ((GameScore.create 0 0 0 1), AwayScores)
        (GameScore.create 1 0 5 9) |> GameScore.update Away |> should equal ((GameScore.create 1 1 0 0), AwayScores)
        (GameScore.create 1 1 5 9) |> GameScore.update Away |> should equal ((GameScore.create 1 2 0 0), AwayWins)