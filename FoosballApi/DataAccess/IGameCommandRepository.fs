namespace FoosballApi.DataAccess

open FoosballApi.Domain

type IGameCommandRepository =
    abstract add: Game -> Game

    abstract update: Game -> Game