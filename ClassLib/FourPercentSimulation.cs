using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class FourPercentSimulation : Simulation
    {
        public const double WithdrawalRate = 0.04;

        public double FirstPayment { get; set; }

        private List<double> HistoricalCpi { get; set; }

        public FourPercentSimulation(List<double> historicalCpi)
        {
            HistoricalCpi = historicalCpi;
        }

        public override double CalculatePayment()
        {
            double payment;

            if (FirstPayment is default(double))
            {
                payment = HistoricalAccountBalance[CurrentYear] * WithdrawalRate;

                FirstPayment = payment;
            } else {
                payment = HistoricalCpi[CurrentYear] / HistoricalCpi[0] * FirstPayment;
            }

            return payment;
        }
    }
}