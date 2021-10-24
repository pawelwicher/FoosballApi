namespace FoosballApi.Application.Model

open System

type GameDto =
    { homeTeamName: string
      awayTeamName: string
      startDate: DateTime
      gameEvents: string seq }