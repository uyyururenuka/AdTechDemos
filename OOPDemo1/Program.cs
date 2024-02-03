using System.ComponentModel;

namespace OOPDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //store employee details and display
            //step-1 : create emp class
            //step-2: create emp object-instantiation
            Employee emp=new Employee();
            //step-3: store the emp data into obj
            //emp.empid = 111;
            //emp.name = "Ravi";
            //emp.salary = 60000;
            emp.Salary = 6000;
            //step-4: process data
            //step-5: display data
            Console.WriteLine(emp.Salary);
        }

    }

    class Employee
    {
         private int empid;
        //automatic property for empid
        public int EmpId
        {
            get;
            set;
        }

         private String name;

        // automatic property for name
        public String Name
        {
            get;
            set;
        }


         int salary;

        //property for salary

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                //validate
                if (value > 50000)
                    salary = value;
                else
                    throw new Exception("Minimum salary sould be 50000");
            }
        }

        public int Exp
        {
            get;
            set;
        }

        public int Bonus
        {
            get;
            set;
        } = 10000;
    }
}
