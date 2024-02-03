namespace OOPDemo1
{
    public class Product // Entity classes (which doesn't have methods and used only for storing.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public string Price { get; set; }
        private int price;
         public int Price
        {
            get { return price; }
            set
            {
                if (price > 0) 
                    price = value;
                else
                    price = 0;
            }
        }
        public string Brand { get; set; }


    }
}
