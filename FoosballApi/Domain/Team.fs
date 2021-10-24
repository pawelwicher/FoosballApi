namespace FoosballApi.Domain

type Team =
    { name: string }

module Team =

    let create name =
        { name = name }