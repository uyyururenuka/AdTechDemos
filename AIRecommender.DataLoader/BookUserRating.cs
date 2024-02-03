using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.DataLoader
{
    public class BookUserRating
    {
        public Book Book { get; set; }
        public User User { get; set; }

        //properties
        public int UserID { get; set; }
        public string ISBN { get; set; }
        public int Rating {  get; set; }

    }
}
