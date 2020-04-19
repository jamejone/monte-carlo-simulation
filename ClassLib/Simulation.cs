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

                if (currentSavings == 0)
                    HistoricalWithdrawalAmount.Add(0);
                else
                    HistoricalWithdrawalAmount.Add(payment);

                var newSavings = currentSavings - payment;

                currentSavings = newSavings < 0 ? 0 : newSavings;

                currentSavings *= (1 + currentYearReturn);

                HistoricalAccountBalance.Add(currentSavings);

                CurrentYear++;
            }
        }

        public abstract double CalculatePayment();
    }
}
