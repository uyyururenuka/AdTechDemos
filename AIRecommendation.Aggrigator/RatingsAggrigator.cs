using AIRecommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Aggrigator
{
    public class RatingsAggrigator : IRatingsAggrigator
    {
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference)
        {
            Dictionary<string, List<int>> aggregatedRatings = new Dictionary<string, List<int>>();
                
            List<BookUserRating> bkr=new List<BookUserRating>();

            List<User> users=new List<User>();

            string s = getAgeGroupPreference(preference.Age);

            foreach(User user in bookDetails.Users)
            {
                if(user.State==preference.State)
                {
                    string userage = getAgeGroupPreference(user.Age);
                    if (userage == s)
                    {
                        users.Add(user);
                    }
                }
            }

            foreach(BookUserRating bookRatings in bookDetails.BookUserRatings)
            {
                foreach(User us in users)
                {
                    if (bookRatings.UserID == us.UserID)
                    {
                        bkr.Add(bookRatings);
                    }
                }
            }

            foreach(Book book in bookDetails.Books)
            {
                List<int> RatingList=new List<int>();

                foreach(BookUserRating bk in bkr)
                {
                    if(book.ISBN == bk.ISBN)
                    {
                        RatingList.Add(bk.Rating);
                    }
                }
                aggregatedRatings.Add(book.ISBN, RatingList);
            }

            return aggregatedRatings;
        }

        private string getAgeGroupPreference(int age)
        {
            string str = " ";
            switch(age) 
            {
                case var Age when (age >= 1 && age <= 16):
                    str = "Teen";
                    break;
                case var Age when (age >= 17 && age <= 30):
                    str = "Young";
                    break;
                case var Age when (age >= 31 && age <= 50):
                    str = "Mid Age";
                    break;
                case var Age when (age >= 51 && age <= 60):
                    str = "Old Age";
                    break;
                case var Age when (age >= 61 && age <= 100):
                    str = "Senior Citizen";
                    break;
                default:
                    return "Enter age<100";

            }
            return str;

        }
    }
}
