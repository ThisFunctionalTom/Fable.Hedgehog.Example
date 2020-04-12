module Tests

open Fable.Mocha
open Hedgehog

let hedgehogTests = testList "Test Hedgehog" [
    testCase "List.rev called twice returns the same list" <| fun _ ->
        property {
            let! xs = Gen.list (Range.linear 0 100) Gen.alpha
            return xs |> List.rev |> List.rev = xs
        } |> Property.check

    testCase "List.rev returns list with same length" <| fun _ ->
        property {
            let! xs = Gen.list (Range.linear 0 100) Gen.alpha
            let reversed = List.rev xs
            return xs.Length = reversed.Length
        } |> Property.check

    testCase "This should fail" <| fun _ ->
        property {
            let! xs = Gen.list (Range.linear 0 100) (Gen.int (Range.linear 0 100))
            return xs.Length < 20
        } |> Property.check
]

let allTests = testList "All" [
    hedgehogTests
]

[<EntryPoint>]
let main (args: string[]) = Mocha.runTests allTests