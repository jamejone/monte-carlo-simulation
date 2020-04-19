using System;
using System.Collections.Generic;

namespace ClassLib
{
    public abstract class Simulation
    {
        private IEnumerable<double> HistoricalReturns { get; set; } = new List<double>();

        public List<double> HistoricalAccountBalance { get; protected set; } = new List<double>();
        
        public List<double> HistoricalWithdrawalAmount { get; protected set; } = new List<double>();

        protected int CurrentYear;

        public Simulation(IEnumerable<double> historicalReturns)
        {
            HistoricalReturns = historicalReturns;
        }

        public void RunSimulation(double currentSavings)
        {
            HistoricalAccountBalance.Add(currentSavings);

            foreach (var currentYearReturn in HistoricalReturns)
            {
                var payment = CalculatePayment();

                HistoricalWithdrawalAmount.Add(payment);

                currentSavings -= payment;

                currentSavings *= (1 + currentYearReturn);

                HistoricalAccountBalance.Add(currentSavings);

                CurrentYear++;
            }
        }

        public abstract double CalculatePayment();
    }
}
