using ClassLib;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var comparisonSim = new ComparisonSim();
            //comparisonSim.Run();

            var dynamicSwrMonteCarlo = new DynamicSwrMonteCarlo();
            dynamicSwrMonteCarlo.Run();
        }
    }
}
