namespace FoosballApi.Domain

type GameScore =
    { home: int
      away: int
      homeGoals: int
      awayGoals: int }

module GameScore =

    let create home away homeGoals awayGoals =
        { home = home
          away = away
          homeGoals = homeGoals
          awayGoals = awayGoals }