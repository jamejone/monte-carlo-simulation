using System.Collections.Generic;
using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Test
{
    [TestClass]
    public class FourPercentSimulationTests
    {
        [TestMethod]
        public void FourPercentSimulationTest()
        {
            var historicalCpi = new List<double>() { 1, 1.02 };
            var historicalReturns = new List<double>() { .06, -.06 };

            var sim = new StaticSwrSimulation(historicalReturns, historicalCpi, 0.04);
            
            sim.RunSimulation(100);

            Assert.AreEqual(91.8192, sim.HistoricalAccountBalance.Last(), 0.001);
        }
    }
}
