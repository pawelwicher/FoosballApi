namespace FoosballApi.Application.Mappers

open FoosballApi.Domain
open FoosballApi.Application.Model

module GameMapper =

    let mapToListDto (game: Game) : GameListDto =
        { id = game.id
          homeTeamName = TeamMapper.map game.homeTeam
          awayTeamName = TeamMapper.map game.awayTeam
          startDate = game.startDate }

    let mapToDto (game: Game) : GameDto =
        { homeTeamName = TeamMapper.map game.homeTeam
          awayTeamName = TeamMapper.map game.awayTeam
          startDate = game.startDate
          gameEvents = game.gameEvents |> Seq.map GameEventMapper.map }