namespace FoosballApi.Domain

open System

type Game =
    { homeTeam: Team
      awayTeam: Team
      startDate: DateTime
      score: GameScore
      gameEvents: GameEvent list }

module Game = 

    let create homeTeam awayTeam startDate score gameEvents =
        { homeTeam = homeTeam
          awayTeam = awayTeam
          startDate = startDate
          score = score
          gameEvents = gameEvents }

    let startMatch homeTeam awayTeam startDate =
        let score = GameScore.create 0 0 0 0
        let startEvent = GameEvent.create startDate GameStarted score
        let game = create homeTeam awayTeam startDate score [startEvent]
        game
        