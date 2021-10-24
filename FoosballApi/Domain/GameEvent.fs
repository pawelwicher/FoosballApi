namespace FoosballApi.Domain

open System

type GameEventType =
    | GameStarted
    | GameFinished
    | HomeScores
    | AwayScores

type GameEvent =
    { date: DateTime
      eventType: GameEventType
      gameScore: GameScore }

module GameEvent =

    let create date eventType gameScore =
        { date = date
          eventType = eventType
          gameScore = gameScore }

