using System;
using System.Collections.Generic;
using System.Linq;
using ClassLib;

namespace Console
{
    public class DynamicSwrMonteCarlo
    {
        private static readonly List<double> VwelxHistoricalReturns = new List<double>()
        {
            22.51, 
            3.42, 
            14.72, 
            11.01, 
            0.06, 
            9.82, 
            19.66, 
            12.57, 
            3.85, 
            10.94, 
            22.2, 
            -22.3, 
            8.34, 
            14.97, 
            6.82, 
            11.17, 
            20.75, 
            -6.9, 
            4.19, 
            10.4, 
            4.41, 
            12.06, 
            23.23, 
            16.19, 
            32.92, 
            -0.49, 
            13.52, 
            7.93, 
            23.65, 
            -2.81, 
            21.6, 
            16.11, 
            2.28, 
            18.4, 
            28.53, 
            10.7, 
            23.57, 
            24.55, 
            2.9, 
            22.58, 
            13.54, 
            5.32, 
            -4.38, 
            23.36, 
            25.18, 
            -17.73, 
            -11.83, 
            10.99, 
            8.88, 
            6.4, 
            -7.83, 
            7.91, 
            8.16, 
            -6.61, 
            5.44, 
            10.85, 
            11.92, 
            -5.17, 
            18.97, 
            5.17, 
            8.86, 
            28.47, 
            -4.3, 
            4.43, 
            15.54, 
            30.86, 
            1.87, 
            10.99, 
            12.32, 
            12.69, 
            16.5, 
            3.85, 
            -3.47, 
            -2.41, 
            23.13, 
            19.37, 
            24.88, 
            16.62, 
            -3.91, 
            0.16, 
            10.31, 
            19.11, 
            35.41, 
            31.33, 
            35.33, 
            20.33, 
            6.83, 
            -1.82, 
            -26.43, 
            -21.21
        };

        private static readonly double StartingAmount = 1500000;

        private static readonly int RetirementAge = 40;

        private static readonly int DeathAge = 90;

        public void Run()
        {
            int yearsOfRetirement = DeathAge - RetirementAge;

            int numberOfSimulations = VwelxHistoricalReturns.Count - yearsOfRetirement;

            var simList = new List<DynamicSwrSimulation>();
            for (int i = 0; i < numberOfSimulations; i++)
            {
                var historicalReturns = VwelxHistoricalReturns.Select(_ => _ / 100).Reverse().Skip(i).Take(yearsOfRetirement);

                var dynamicSwrSim = new DynamicSwrSimulation(historicalReturns, RetirementAge, DeathAge);

                dynamicSwrSim.RunSimulation(StartingAmount);

                simList.Add(dynamicSwrSim);
            }

            System.Console.WriteLine("HistoricalAccountBalance");
            foreach (var sim in simList)
            {
                System.Console.WriteLine(String.Join(',', sim.HistoricalAccountBalance));
            }

            System.Console.WriteLine("HistoricalWithdrawalAmount");
            foreach (var sim in simList)
            {
                System.Console.WriteLine(String.Join(',', sim.HistoricalWithdrawalAmount));
            }
        }
    }
}