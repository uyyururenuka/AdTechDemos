using AIRecommendation.Aggrigator;
using AIRecommender.DataLoader;

namespace AIRecommendation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AIRecommendationEngine recommender = new AIRecommendationEngine();
            IDataLoader dataLoader = new CSVDataLoader();
            BookDetails bookDetails = dataLoader.Load();

            Preference preference = new Preference { ISBN = "034545104X" ,State="california",Age=25 };

            List<Book> recommendedBooks=recommender.Recommend(bookDetails,preference,10);

            //need to display it


            foreach(Book book in recommendedBooks)
            {
                Console.WriteLine(book);
            }

        }
    }
}
