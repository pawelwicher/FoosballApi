namespace FoosballApi.Domain

open System

type Game =
    { id: int
      homeTeam: Team
      awayTeam: Team
      startDate: DateTime
      gameEvents: GameEvent seq }

module Game = 

    let create homeTeam awayTeam startDate score gameEvents =
        { id = 0
          homeTeam = homeTeam
          awayTeam = awayTeam
          startDate = startDate
          gameEvents = gameEvents }

    let startGame homeTeamName awayTeamName startDate =
        let homeTeam = Team.create homeTeamName
        let awayTeam = Team.create awayTeamName
        let score = GameScore.create 0 0 0 0
        let startEvent = GameEvent.create startDate GameCreated score
        let game = create homeTeam awayTeam startDate score [startEvent]
        game

    let update teamToScore date game =
        let lastEvent = game.gameEvents |> Seq.head

        if lastEvent.eventType = HomeWins || lastEvent.eventType = AwayWins then
            game
        else
            let score, eventType = GameScore.update teamToScore lastEvent.gameScore        
            let newEvent = GameEvent.create date eventType score
            { game with gameEvents = game.gameEvents |> Seq.append [newEvent] }    