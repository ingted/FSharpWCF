namespace AsianOptionsServiceFSharpLib.Services

open System
open AsianOptionsServiceFSharpLib.Contracts

type AsianOptionsService() =
    interface IAsianOptionsServiceFSharp with
        override this.PriceAsianOptions(initial:float, exercise:float, up:float
            , down:float, interest:float, periods:int32, runs:int) = 0.0;
