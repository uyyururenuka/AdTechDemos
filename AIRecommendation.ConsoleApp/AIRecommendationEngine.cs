using AIRecommendation.Aggrigator;
using AiRecommendeationCoreEngine;
using AIRecommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.ConsoleApp
{
    public  class AIRecommendationEngine
    {
         public List<Book> Recommend(BookDetails bookDetails, Preference preference, int limit)
        {
            IRatingsAggrigator ratingsAggrigator = new RatingsAggrigator();
            Dictionary<string, List<int>> dictOfISBNratings = ratingsAggrigator.Aggrigate(bookDetails,preference);

            List<int> ExtractedList = new List<int>();

            if (dictOfISBNratings.ContainsKey(preference.ISBN))
            {
                ExtractedList = dictOfISBNratings[preference.ISBN];
            }
            IRecommender pearson = new PearsonRecommender();
            pearson.GetCorrrelation(ExtractedList, ); //List<int> otherArray);


            //list of books
            List<Book> books = new List<Book>();
            //for ()
            //{
            //    books.Add(ISBN);
            //}
            return books;
        }

        
    }
}
