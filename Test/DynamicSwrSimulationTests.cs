using ClassLib;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class DynamicSwrSimulationTests
    {
        [TestMethod]
        public void DynamicSwrSimulationTest()
        {
            var historicalReturns = new List<double>() { .06, -.06 };

            var sim = new DynamicSwrSimulation(historicalReturns, 40, 100);
            
            sim.RunSimulation(100);

            Assert.AreEqual(90.9661312, sim.HistoricalAccountBalance.Last(), 0.001);
        }
    }
}