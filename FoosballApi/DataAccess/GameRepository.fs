namespace FoosballApi.DataAccess

open LiteDB
open LiteDB.FSharp

open FoosballApi.Configuration
open FoosballApi.Domain

type GameRepository() =
    let getCollection () =
        use db = new LiteDatabase(AppSettings.connectionString, FSharpBsonMapper())
        db.GetCollection<Game>("games")

    interface IGameQueryRepository with
        member _.getList () =
            let gamesCollection = getCollection ()
            gamesCollection.FindAll()

        member _.get id =
            let gamesCollection = getCollection ()
            gamesCollection.FindOne(fun x -> x.id = id)

    interface IGameCommandRepository with
        member _.add game =
            let gamesCollection = getCollection ()
            let games = gamesCollection.FindAll()
            let maxId =
                if Seq.length games = 0 then
                    0
                else
                    games
                    |> Seq.map (fun x -> x.id)
                    |> Seq.max
            let newGame = { game with id = maxId + 1 } 
            gamesCollection.Insert newGame |> ignore
            newGame

        member _.update game =
            let gamesCollection = getCollection ()
            gamesCollection.Update game |> ignore
            game