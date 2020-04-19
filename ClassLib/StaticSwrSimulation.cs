using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class StaticSwrSimulation : Simulation
    {
        private readonly double WithdrawalRate;

        public double FirstPayment { get; set; }

        private List<double> HistoricalCpi { get; set; }

        public StaticSwrSimulation(List<double> historicalReturns, List<double> historicalCpi, double withdrawalRate)
            : base(historicalReturns)
        {
            HistoricalCpi = historicalCpi;
            WithdrawalRate = withdrawalRate;
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