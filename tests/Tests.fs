module Tests

open Fable.Mocha
open Hedgehog
open Hedgehog.Mocha

let hedgehogTests = testList "Test Hedgehog" [
    testProperty "List.rev called twice returns the same list" <|
        property {
            let! xs = Gen.list (Range.linear 0 100) Gen.alpha
            return xs |> List.rev |> List.rev = xs
        }

    testProperty' 200<tests> "List.rev returns list with same length" <|
        property {
            let! xs = Gen.list (Range.linear 0 100) Gen.alpha
            let reversed = List.rev xs
            return xs.Length = reversed.Length
        }

    testProperty "This should fail" <|
        property {
            let! xs = Gen.list (Range.linear 0 100) (Gen.int (Range.linear 0 100))
            return xs.Length < 20
        }
]

let allTests = testList "All" [
    hedgehogTests
]

[<EntryPoint>]
let main (args: string[]) = Mocha.runTests allTests