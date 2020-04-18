using System;
using System.Collections.Generic;

namespace ClassLib
{
    public abstract class Simulation
    {
        public List<double> HistoricalReturns { get; set; } = new List<double>();

        public List<double> HistoricalAccountBalance { get; set; } = new List<double>();
        
        public List<double> HistoricalWithdrawalAmount { get; set; } = new List<double>();

        public int CurrentYear { get; set; }

        public void RunSimulation(double currentSavings)
        {
            HistoricalAccountBalance.Add(currentSavings);

            for (CurrentYear = 0; CurrentYear < HistoricalReturns.Count; CurrentYear++)
            {
                var payment = CalculatePayment();

                HistoricalWithdrawalAmount.Add(payment);

                currentSavings -= payment;

                currentSavings *= (1 + HistoricalReturns[CurrentYear]);

                HistoricalAccountBalance.Add(currentSavings);
            }
        }

        public abstract double CalculatePayment();
    }
}
