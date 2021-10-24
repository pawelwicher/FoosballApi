namespace FoosballApi.Application.Mappers

open FoosballApi.Domain

module GameScoreMapper =

    let map (gameScore: GameScore): string =
        $"Home {gameScore.homeSets} ({gameScore.homeGoals}) - Away {gameScore.awaySets} ({gameScore.awayGoals})"

