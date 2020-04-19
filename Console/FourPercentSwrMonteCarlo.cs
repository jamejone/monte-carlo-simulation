using System;
using System.Collections.Generic;
using System.Linq;
using ClassLib;

namespace Console
{
    public class FourPercentSwrMonteCarlo
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

        private static readonly List<double> HistoricalCpi = new List<double>()
        {
            16.7, 
            15.20833333, 
            13.64166667, 
            12.93333333, 
            13.38333333, 
            13.725, 
            13.86666667, 
            14.38333333, 
            14.09166667, 
            13.90833333, 
            14.00833333, 
            14.725, 
            16.33333333, 
            17.30833333, 
            17.59166667, 
            17.99166667, 
            19.51666667, 
            22.325, 
            24.04166667, 
            23.80833333, 
            24.06666667, 
            25.95833333, 
            26.55, 
            26.76666667, 
            26.85, 
            26.775, 
            27.18333333, 
            28.09166667, 
            28.85833333, 
            29.15, 
            29.575, 
            29.89166667, 
            30.25, 
            30.625, 
            31.01666667, 
            31.50833333, 
            32.45833333, 
            33.35833333, 
            34.78333333, 
            36.68333333, 
            38.825, 
            40.49166667, 
            41.81666667, 
            44.4, 
            49.30833333, 
            53.81666667, 
            56.90833333, 
            60.60833333, 
            65.23333333, 
            72.575, 
            82.40833333, 
            90.925, 
            96.5, 
            99.6, 
            103.8833333, 
            107.5666667, 
            109.6083333, 
            113.625, 
            118.2583333, 
            123.9666667, 
            130.6583333, 
            136.1916667, 
            140.3166667, 
            144.4583333, 
            148.225, 
            152.3833333, 
            156.85, 
            160.5166667, 
            163.0083333, 
            166.575, 
            172.2, 
            177.0666667, 
            179.875, 
            183.9583333, 
            188.8833333, 
            195.2916667, 
            201.5916667, 
            207.3424167, 
            215.3025, 
            214.537, 
            218.0555, 
            224.9391667, 
            229.5939167, 
            232.9570833, 
            236.7361667, 
            237.017, 
            240.0071667, 
            245.1195833, 
            251.1068333, 
            255.6574167
        };

        private static readonly double StartingAmount = 1500000;

        private static readonly int RetirementAge = 40;

        private static readonly int DeathAge = 90;

        public void Run()
        {
            int yearsOfRetirement = DeathAge - RetirementAge;

            int numberOfSimulations = VwelxHistoricalReturns.Count - yearsOfRetirement;

            var simList = new List<StaticSwrSimulation>();
            for (int i = 0; i < numberOfSimulations; i++)
            {
                var historicalReturns = VwelxHistoricalReturns.Select(_ => _ / 100).Reverse().Skip(i).Take(yearsOfRetirement);

                var historicalCpi = HistoricalCpi.Select(_ => _ / 100).Skip(i).Take(yearsOfRetirement);

                var staticSwrSim = new StaticSwrSimulation(historicalReturns, historicalCpi, 0.04);

                staticSwrSim.RunSimulation(StartingAmount);

                simList.Add(staticSwrSim);
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