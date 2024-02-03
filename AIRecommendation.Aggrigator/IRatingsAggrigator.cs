using AIRecommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Aggrigator
{
    public  interface IRatingsAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails,Preference preference);
        
    }
}
