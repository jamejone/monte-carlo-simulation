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
            var sim = new DynamicSwrSimulation(40, 100);
            
            sim.HistoricalReturns = new List<double>() { .06, -.06 };
            sim.RunSimulation(100);

            Assert.AreEqual(90.9661312, sim.HistoricalAccountBalance.Last(), 0.001);
        }
    }
}