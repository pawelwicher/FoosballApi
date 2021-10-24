namespace FoosballApi.Controllers

open Microsoft.AspNetCore.Mvc

open FoosballApi.Application.Service

[<ApiController>]
[<Route("[controller]")>]
type GameController (gameAppService: IGameAppService) =
    inherit ControllerBase()
    
    [<HttpGet>]
    member _.get() =
        gameAppService.getList ()

    [<HttpGet("{id}")>]
    member _.get id =
        gameAppService.get id

    [<HttpPost("start")>]
    member _.start gameStartCommandDto =
        gameAppService.startGame gameStartCommandDto

    [<HttpPost("homeScores")>]
    member _.homeScores homeScoresCommandDto =
        gameAppService.homeScores homeScoresCommandDto

    [<HttpPost("awayScores")>]
    member _.awayScores awayScoresCommandDto =
        gameAppService.awayScores awayScoresCommandDto