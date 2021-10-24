namespace FoosballApi.Tests.Domain

open Xunit
open FsUnit.Xunit

open FoosballApi.Domain

module TeamTests =

    [<Fact>]
    let ``should create``() =
        let actual = Team.create "team1"

        let expected =
            { name = "team1" }

        actual |> should equal expected