namespace AsianOptionsServiceFSharpLib.Services

open System
open AsianOptionsServiceFSharpLib.Contracts

type AsianOptionsFSharp() =
    interface IAsianOptionsServiceFSharp with
        override this.PriceAsianOptions(initial:float, exercise:float, up:float
            , down:float, interest:float, periods:int32, runs:int32) = 
            
            (*let initial = 30.0;;
            let exercise = 30.0;;
            let up = 1.4;;
            let down = 0.8;;
            let interest = 1.08;;
            let periods = 20;;
            let runs = 1000000;;*)

            let pricePath = Array.create (periods + 1) 0.0
            let piup = (interest - down) / (up - down)
            let pidown = ref (1.0 - piup)
            let temp = ref 0.0
            let rand = new System.Random()
            let priceAverage = 0.0
            let callPayOff = 0.0
            {0..(runs - 1)} |> Seq.iter (
                fun _ ->
                    let sumPricePath = ref 0.0
                    sumPricePath.Value <- initial  
                    
                    {1..periods} |> Seq.iter (
                        fun i -> 
                            pricePath.[0] <- initial
                            let rn = rand.NextDouble()
                            match rn with
                            | x when x > pidown.Value ->
                                pricePath.[i] <- pricePath.[i - 1] * up
                            | _ ->
                                pricePath.[i] <- pricePath.[i - 1] * down
                            sumPricePath.Value <- sumPricePath.Value + pricePath.[i] //*)
                    );
                    let priceAverage = sumPricePath.Value / (float periods + 1.0) * 1.0
                    let callPayOff = System.Math.Max((priceAverage - exercise), 0.0)
                    temp.Value <- temp.Value + callPayOff
            )

            (temp.Value / System.Math.Pow(interest, float periods)) / (float runs);
            //*)