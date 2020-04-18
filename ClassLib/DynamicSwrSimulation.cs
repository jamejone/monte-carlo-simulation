using System;

namespace ClassLib
{
    public class DynamicSwrSimulation : Simulation
    {
        private const double RoiTarget = 0.06;

        private const double InflationTarget = 0.02;

        private readonly int StartingAge;

        private readonly int DeathAge;

        public DynamicSwrSimulation(int startingAge, int deathAge)
        {
            StartingAge = startingAge;
            DeathAge = deathAge;
        }

        //let firstPayment = totalValueOfSavings * (roi - inflation) / (1 - Math.pow((1 + inflation) / (1 + roi), yearsInRetirement));
        public override double CalculatePayment()
        {return HistoricalAccountBalance[CurrentYear] * (RoiTarget - InflationTarget) / (1 - Math.Pow((1 + InflationTarget) / (1 + RoiTarget), DeathAge - StartingAge - CurrentYear));
            
        }
    }
}