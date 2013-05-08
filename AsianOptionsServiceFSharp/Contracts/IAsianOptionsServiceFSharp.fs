namespace AsianOptionsServiceFSharpLib.Contracts

open System.Runtime.Serialization
open System.ServiceModel

[<ServiceContract>]
type IAsianOptionsServiceFSharp =
    [<OperationContract>]
    abstract PriceAsianOptions : initial:float * exercise:float * up:float *
            down:float * interest:float * periods:int32 * runs:int -> float;





    (*
    (initial:float, exercise:float, up:float, 
            down:float, interest:float, periods:int32, runs:int)*)
