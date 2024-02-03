namespace OODemo4
{
    internal class Program
    {
        private static object order;

        static void Main(string[] args)
        {   
            //comapny class
            Company company=new Company();

            Customer cus1=new Customer();
            Customer cus2 = new Customer();
            Customer cus3= new RegCustomer { SplDiscount = 0.1 } ;

            company.Customers.Add(cus1);
            company.Customers.Add(cus2);
            company.Customers.Add(cus3);

            Item item1= new Item { Desc="Biscuit",Rate=45.0};
            Item item2= new Item { Desc ="Chocolate",Rate = 65.0 };
            Item item3 = new Item { Desc = "Bevarage", Rate = 89.0 };

            company.Items.Add(item1);
            company.Items.Add(item2);
            company.Items.Add(item3);

            //creating an order for customer1
            Order order=new Order();//creating an object for Order class
            order.Customers = cus1;//creating an order for customer1
            OrderedItem ordereditem1= new OrderedItem {Items=item1,Qty=3};
            OrderedItem ordereditem2= new OrderedItem {  Items=item2,Qty=5};
            order.OrderedItems.Add(ordereditem1);//adding ordereditems to an order
            order.OrderedItems.Add(ordereditem2);
            cus1.orders.Add(order);//adding orders to customer1

            //to get total worth of orders placed by a customer
            double TotalWorth = company.GetTotalWorthOfOrderPlaced();
            Console.WriteLine($"Th Total worth of the orders placed:{TotalWorth}");

        }

    }

    class Company
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Item> Items { get; set; } = new List<Item> ();
        public double GetTotalWorthOfOrderPlaced()
        {
            double totalworth = 0.0;
            foreach(Customer customer in Customers)
            {
                totalworth += customer.GetTotalOrderValue();
            }
            return totalworth;
        }


    }

    class Customer
    {

       public List<Order> orders { get; set; }=new List<Order> ();
        public virtual double GetTotalOrderValue()
        {
            double totalvalue = 0.0;
            foreach(Order order in orders)
            {
                totalvalue += order.GetTotalOrderValue();
            }
            return totalvalue;
        }
        

    }
    class RegCustomer : Customer
    {
        public double SplDiscount { get; set; }

        public override double GetTotalOrderValue()
        {
            // Apply special discount for regular customers
            double totalOrderValue = base.GetTotalOrderValue();
            return totalOrderValue - (totalOrderValue * SplDiscount);
        }
    }
    class Item
    {
        public string Desc { get; set; }
        public double Rate { get; set; }

    }
    class Order
    {
        public Customer Customers { get; set; } //for order there is only one customer don't confuse as there is name "customers"
        public List<OrderedItem> OrderedItems { get; set; }=new List<OrderedItem> ();
        public double CalculateTotalItemValue(OrderedItem orderedItem)
        {
            return orderedItem.TotalItemValue();
        }
        public double GetTotalOrderValue()
        {
            return OrderedItems.Sum(CalculateTotalItemValue);
        }
    }
    class OrderedItem
    {
        public Item Items { get; set; }
        public int Qty { get; set; }
        public double TotalItemValue()
        {
            return Qty * Items.Rate;
        }
        
    }
}



