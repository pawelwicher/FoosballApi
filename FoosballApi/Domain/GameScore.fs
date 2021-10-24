namespace FoosballApi.Domain

type TeamToScore =
    | Home
    | Away

type GameScore =
    { homeSets: int
      awaySets: int
      homeGoals: int
      awayGoals: int }

module GameScore =

    let create homeSets awaySets homeGoals awayGoals =
        { homeSets = homeSets
          awaySets = awaySets
          homeGoals = homeGoals
          awayGoals = awayGoals }

    let update teamToScore score =
        match (teamToScore, score) with
        | (Home, { homeSets = 1; homeGoals = 9 }) -> (create 2 score.awaySets 0 0, HomeWins)
        | (Away, { awaySets = 1; awayGoals = 9 }) -> (create score.homeSets 2 0 0, AwayWins)
        | (Home, { homeGoals = 9 }) -> (create 1 score.awaySets 0 0, HomeScores)
        | (Away, { awayGoals = 9 }) -> (create score.homeSets 1 0 0, AwayScores)
        | (Home, _) -> ({ score with homeGoals = score.homeGoals + 1 }, HomeScores)
        | (Away, _) -> ({ score with awayGoals = score.awayGoals + 1 }, AwayScores)