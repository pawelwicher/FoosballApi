namespace FoosballApi.Application.Model

open System

type GameListDto =
    { id: int
      homeTeamName: string
      awayTeamName: string
      startDate: DateTime }