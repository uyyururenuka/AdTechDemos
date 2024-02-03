using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public static List<Book> books= new List<Book>();
        public static List<User> users= new List<User>();
        public static List<BookUserRating> bookUserRatings = new List<BookUserRating>();
        public static StreamReader reader = null;
            static void  booksFile()
            {
                reader = new StreamReader("AIRecommender.DataLoader\\csv-data\\BX-Books.csv");
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] arr_books = line.Split(',');
                    books = arr_books.Cast<Book>().ToList();

                }
                reader.Close();
                
            }
            static void usersFile()
            {
                StreamReader reader = new StreamReader("AIRecommender.DataLoader\\csv-data\\BX-Users.csv");
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] arr_users = line.Split(',');
                    users = arr_users.Cast<User>().ToList();
                }
            reader.Close();
            }
            static void  ratingsFile()
            {
                StreamReader reader = new StreamReader("AIRecommender.DataLoader\\csv-data\\BX-Book-Ratings.csv");
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] arr_ratings = line.Split(',');
                    bookUserRatings = arr_ratings.Cast<BookUserRating>().ToList();
                }
                reader.Close();
            }


        public BookDetails Load()
        {
            Task t1 = new Task(booksFile);
            t1.Start();
            Task t2 = new Task(usersFile);
            t2.Start();
            Task t3 = new Task(ratingsFile);
            t3.Start();
            t1.Wait();
            t2.Wait();
            t3.Wait();
            BookDetails bookdetails = new BookDetails()
            {
                Books = books,
                Users = users,
                BookUserRatings = bookUserRatings
            };
            
            return bookdetails; 
        }
        
    }
}
