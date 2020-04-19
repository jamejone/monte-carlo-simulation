using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib
{
    public class StaticSwrSimulation : Simulation
    {
        private readonly double WithdrawalRate;

        public double FirstPayment { get; set; }

        private List<double> HistoricalCpi { get; set; }

        public StaticSwrSimulation(IEnumerable<double> historicalReturns, IEnumerable<double> historicalCpi, double withdrawalRate)
            : base(historicalReturns)
        {
            HistoricalCpi = historicalCpi.ToList();
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