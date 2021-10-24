namespace FoosballApi.Application.Service

open System

open FoosballApi.Domain
open FoosballApi.DataAccess
open FoosballApi.Application.Mappers

type GameAppService (gameQueryRepository: IGameQueryRepository, gameCommandRepository: IGameCommandRepository) =

    let teamScores gameId teamToScore =
        gameId
        |> gameQueryRepository.get 
        |> Game.update teamToScore DateTime.Now
        |> gameCommandRepository.update
        |> GameMapper.mapToDto

    interface IGameAppService with
        member _.getList () =
            gameQueryRepository.getList ()
            |> Seq.sortByDescending (fun x -> x.startDate)
            |> Seq.map GameMapper.mapToListDto

        member _.get id =
            gameQueryRepository.get id
            |> GameMapper.mapToDto

        member _.startGame gameStartCommand =
            Game.startGame gameStartCommand.homeTeamName gameStartCommand.awayTeamName DateTime.Now
            |> gameCommandRepository.add
            |> GameMapper.mapToDto


        member _.homeScores homeScoresCommandDto =
            teamScores homeScoresCommandDto.gameId Home

        member _.awayScores awayScoresCommandDto =
            teamScores awayScoresCommandDto.gameId Away