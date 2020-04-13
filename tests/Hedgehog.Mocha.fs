module Hedgehog.Mocha

open Hedgehog
open Fable.Mocha

let testProperty name property =
    testCase name <| fun _ ->
        Property.check property

let testProperty' count name property =
    testCase name <| fun _ ->
        Property.check' count property