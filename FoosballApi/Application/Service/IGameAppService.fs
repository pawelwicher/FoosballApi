namespace FoosballApi.Application.Service

open FoosballApi.Application.Model

type IGameAppService =
    abstract getList: unit -> GameListDto seq

    abstract get: id: int -> GameDto

    abstract start: startCommandDto: GameStartCommandDto -> GameDto

    abstract homeScores: homeScoresCommandDto: HomeScoresCommandDto -> GameDto

    abstract awayScores: awayScoresCommandDto: AwayScoresCommandDto -> GameDto