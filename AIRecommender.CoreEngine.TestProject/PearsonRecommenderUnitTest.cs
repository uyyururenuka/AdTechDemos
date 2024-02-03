using AiRecommendeationCoreEngine;
namespace AIRecommender.CoreEngine.TestProject
{
    [TestClass]
    public class PearsonRecommenderUnitTest
    {
        PearsonRecommender target = null;
        [TestInitialize]
        public void Init()
        {
            target= new PearsonRecommender();
        }
        [TestMethod]
        public void GetCorrelation_OnSuccess_CalculateCorrelation()
        {
            List<int> baseArray = new List<int> { 3, 6, 8, 9, 7 };
            List<int> otherArray = new List<int> { 8, 9, 5, 7, 4 };
            //PearsonRecommender target = new PearsonRecommender();
            double core = target.GetCorrrelation(otherArray, baseArray);
            core = Math.Round(core, 4);
            double R = -0.4608;
            Assert.AreEqual(R, core);

        }

        [TestMethod]
        public void GetCorrelation_IfZeros_Found()
        {
            List<int> baseArray = new List<int> { 3, 0, 8, 9, 7 };
            List<int> otherArray = new List<int> { 8, 9, 0, 7, 4 };
            //PearsonRecommender target = new PearsonRecommender();
            double core = target.GetCorrrelation(otherArray, baseArray);
            core = Math.Round(core, 4);
            double R = -0.7785;
            Assert.AreEqual(R, core);
        }

        [TestMethod]
        public void GetCorrelation_IfBaseIsGreater_Add1()
        {
            List<int> baseArray = new List<int> { 3, 6, 8, 9, 7, 2 };
            List<int> otherArray = new List<int> { 8, 9, 5, 7, 4 };
            //PearsonRecommender target = new PearsonRecommender();
            double core = target.GetCorrrelation(baseArray, otherArray);
            core = Math.Round(core, 4);
            double R = 0.2148;
            Assert.AreEqual(R, core);
        }

        [TestMethod]
        public void GetCorrelation_IfBaseIsLesser_Trim()
        {
            List<int> baseArray = new List<int> { 3, 6, 8, 9, 12};
            List<int> otherArray = new List<int> { 8, 9, 5, 7, 4, 6, 2, 3 };
            //PearsonRecommender target = new PearsonRecommender();
            double core = target.GetCorrrelation(baseArray, otherArray);
            core = Math.Round(core, 4);
            double R = -0.7818;
            Assert.AreEqual(R, core);
        }



    }
}