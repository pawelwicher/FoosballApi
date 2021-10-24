namespace FoosballApi.Application.Mappers

open FoosballApi.Domain

module GameEventMapper =

    let map (gameEvent: GameEvent): string =
        $"[{gameEvent.date}] {gameEvent.eventType}, score: {GameScoreMapper.map gameEvent.gameScore}"