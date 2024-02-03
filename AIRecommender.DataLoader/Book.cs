using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.DataLoader
{
    public class Book
    {
        //Add Book Properties
        public  string BookTitle { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public string InageurlSnall { get; set; }
        public string InageurlMedium { get; set; }
        public string InageurlLarge { get; set; }

        public List<BookUserRating> BookUserRatings { get; set;} = new List<BookUserRating>();

    }
}
