namespace FoosballApi.Application.Mappers

open FoosballApi.Domain

module TeamMapper =

    let map (team: Team): string =
        team.name