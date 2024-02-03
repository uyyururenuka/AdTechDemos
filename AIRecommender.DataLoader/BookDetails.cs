using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.DataLoader
{
    public class BookDetails
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>();
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();
    }
}
