using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendeationCoreEngine
{
    public class PearsonRecommender : IRecommender
    {
        public double GetCorrrelation(List<int> OriginlbaseArray, List<int> OriginalotherArray)
        {
            List<int> baseArray = new List<int>(OriginlbaseArray);
            List<int> otherArray = new List<int>(OriginalotherArray);
            


            ////business rules
            //1.Both the arrays should be of same length
            if (baseArray.Count != otherArray.Count)
            {
                //if basearray is greater than the other array then Add 1 to corresponding array elements
                if (baseArray.Count > otherArray.Count)
                {
                    for (int i = otherArray.Count; i < baseArray.Count; i++)
                    {
                        baseArray[i] += 1;
                        otherArray.Add(1);
                    }
                }

                //if basearray is less than the otherArray we need to trim the otherArray , we can do that through RemoveRange method
                //RemoveRange(2,3)-it will remove from index 2 upto 3 elements
                else
                {
                    otherArray.RemoveRange(baseArray.Count, otherArray.Count - baseArray.Count);
                }

            }
            //if both arrays are Equal and if any one of the arrays has 0 as element then Add 1 to both corresponding array element
            for (int i = 0; i < baseArray.Count; i++)
            {
                if (baseArray[i] == 0 || otherArray[i] == 0)
                {
                    baseArray[i] += 1;
                    otherArray[i] += 1;
                }
            }



            int SumOfMultiplication(List<int> baseArray, List<int> otherArray)
            {
                int SumOfMultipli = 0;

                for (int i = 0; i < baseArray.Count; i++)
                {
                    SumOfMultipli += baseArray[i] * otherArray[i];
                }
                return SumOfMultipli;
            }
            int baseArraySum = baseArray.Sum();
            int otherArraySum = otherArray.Sum();
            int sumOfMultiOfTwoArrays = SumOfMultiplication(baseArray, otherArray);
            int sumOfSquaresOfbaseArray= baseArray.Select(x => x * x).Sum();
            int sumOfSquaresOfotherArray = otherArray.Select(x => x * x).Sum();
            double R1 = (baseArray.Count * sumOfMultiOfTwoArrays) -(baseArraySum*otherArraySum);
            double R2 = (((baseArray.Count * sumOfSquaresOfbaseArray) - (baseArraySum * baseArraySum)) * ((otherArray.Count * sumOfSquaresOfotherArray) - (otherArraySum * otherArraySum)));
            
            double R = R1 / Math.Sqrt(R2);

            return R;
        }


       

        
        //public int SumOfMultiplication(List<int> baseArray, List<int> otherArray)
        //{
        //    int SumOfMultipli = 0;

        //    for (int i = 0; i < baseArray.Count; i++)
        //    {
        //        SumOfMultipli += baseArray[i] * otherArray[i];
        //    }
        //    return SumOfMultipli;
        //}
    }
}
