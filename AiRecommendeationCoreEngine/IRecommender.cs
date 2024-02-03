using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendeationCoreEngine
{
    public interface IRecommender
    {
        double GetCorrrelation(List<int> baseArray,List<int> otherArray);
    }
}
