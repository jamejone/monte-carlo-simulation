using ClassLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    class Program
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
            5.17
        };

        private static readonly List<double> SAndPHistoricalReturns = new List<double>()
        {
            31.49,
            -4.38,
            21.83,
            11.96,
            1.38,
            13.69,
            32.39,
            16,
            2.11,
            15.06,
            26.46,
            -37,
            5.49,
            15.79,
            4.91,
            10.88,
            28.68,
            -22.1,
            -11.89,
            -9.1,
            21.04,
            28.58,
            33.36,
            22.96,
            37.58,
            1.32,
            10.08,
            7.62,
            30.47,
            -3.1,
            31.69,
            16.61,
            5.25,
            18.67,
            31.73,
            6.27,
            22.56,
            21.55,
            -4.91,
            32.42,
            18.44,
            6.56,
            -7.18,
            23.84,
            37.2,
            -26.47,
            -14.66,
            18.98,
            14.31,
            4.01,
            -8.5,
            11.06,
            23.98,
            -10.06,
            12.45,
            16.48,
            22.8,
            -8.73,
            26.89,
            0.47
        };

        private static readonly List<double> HistoricalCpi = new List<double>() {
            29.585,
            29.902,
            30.253,
            30.633,
            31.038,
            31.528,
            32.471,
            33.375,
            34.792,
            36.683,
            38.842,
            40.483,
            41.808,
            44.425,
            49.317,
            53.825,
            56.933,
            60.617,
            65.242,
            72.583,
            82.383,
            90.933, 
            96.533, 
            99.583, 
            103.933, 
            107.600, 
            109.692, 
            113.617, 
            118.275, 
            123.942, 
            130.658, 
            136.167, 
            140.308, 
            144.475, 
            148.225, 
            152.383, 
            156.858, 
            160.525, 
            163.008, 
            166.583, 
            172.192, 
            177.042, 
            179.867, 
            184.000, 
            188.908, 
            195.267, 
            201.558, 
            207.344, 
            215.254, 
            214.565, 
            218.076, 
            224.923, 
            229.586, 
            232.952, 
            236.715, 
            237.002, 
            239.989, 
            245.121, 
            251.101, 
            255.651
        };

        private static readonly double StartingAmount = 1000000;

        static void Main(string[] args)
        {
            var historicalReturns = VwelxHistoricalReturns.Select(_ => _ / 100).Reverse().ToList();

            var dynamicSwrSim = new DynamicSwrSimulation(40, 100);
            dynamicSwrSim.HistoricalReturns = historicalReturns;
            var fourPercentSim = new FourPercentSimulation(HistoricalCpi);
            fourPercentSim.HistoricalReturns = historicalReturns;

            dynamicSwrSim.RunSimulation(StartingAmount);
            fourPercentSim.RunSimulation(StartingAmount);

            System.Console.WriteLine("4% SWR");
            System.Console.WriteLine("Historical account balance:");
            foreach (var item in fourPercentSim.HistoricalAccountBalance) 
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("Historical withdrawals:");
            foreach (var item in fourPercentSim.HistoricalWithdrawalAmount) 
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Dynamic SWR");
            System.Console.WriteLine("Historical account balance:");
            foreach (var item in dynamicSwrSim.HistoricalAccountBalance) 
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("Historical withdrawals:");
            foreach (var item in dynamicSwrSim.HistoricalWithdrawalAmount) 
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
