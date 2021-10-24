namespace FoosballApi.DataAccess

open FoosballApi.Domain

type IGameQueryRepository =
    abstract getList: unit -> Game seq

    abstract get: id: int -> Game