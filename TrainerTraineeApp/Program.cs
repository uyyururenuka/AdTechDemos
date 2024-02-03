namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //display training org name
            Training training = new Training();
            Trainer trainer= new Trainer();
            training.TheTrainer = trainer;
            Organization organization=new Organization { Name = "AdTech Corporation" };
            trainer.TheOrganization = organization;
            Console.WriteLine($"The Training org Name : {training.GetTrainingOrgName()}");
              
            //to get count of trainees
            Trainee t1= new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();
            Trainee t4 = new Trainee();
            Trainee t5 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            training.Trainees.Add(t4);
            training.Trainees.Add(t5);

            Console.WriteLine($"The Number of trainess : {training.GetNumberOfTrainees()}");

            //to get duration in hrs
            Course course=new Course();
            training.Course= course;

            Module m1 = new Module();
            Module m2= new Module();
            Module m3= new Module();

            course.Modules.Add(m1);
            course.Modules.Add(m2);
            course.Modules.Add(m3);

            Unit u1 = new Unit { DurationHrs = 5 };
            Unit u2 = new Unit { DurationHrs = 10 };
            m1.Units.Add(u1);
            m1.Units.Add(u2);

            Unit u3 = new Unit { DurationHrs = 10 };
            Unit u4 = new Unit { DurationHrs = 10 };
            m2.Units.Add(u3);
            m2.Units.Add(u4);

            Unit u5 = new Unit { DurationHrs = 10 };
            m3.Units.Add(u5);

            Console.WriteLine($"The duration of training in hrs: {training.GetTrainingDurationInHrs()}");
        }
    }

    class Organization
    {
        public string Name { get; set; }
    }
    
    class Trainer
    {
        public Organization TheOrganization { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
        
    }

    class Trainee
    {
        public Trainer TheTrainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
        

        

    }

    class Training
    {
        public Trainer TheTrainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();//list type
        public Trainee Trainees2 { get; set; } //
        public Course Course { get; set; }
        public String GetTrainingOrgName()
        {
            //return Training organization name
            //need to first talk to trainer then trainer talk to organization through "TheOrganization" instance
            return TheTrainer.TheOrganization.Name;
        }
        public int GetNumberOfTrainees()
        {
            //count number of participants and return
            return Trainees.Count;
        }
        public int GetTrainingDurationInHrs()
        {
            //calculate the duration
            int totDuration = 0;
            //for each modules
            foreach(var module in Course.Modules)
            {
                foreach(var unit in module.Units)
                {
                    totDuration += unit.DurationHrs;
                }
            }
            return totDuration;
        }
    }
    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();

        
    }

    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
        
    }
    class Unit
    {
        public List<Topic> Topics { get; set; } = new List<Topic>();

        public int DurationHrs {  get; set; }

        public int GetDurationHrs()
        {
            return 0;//for instace it is 0
        }



    }
    class Topic
    {
        public String Name {  get; set; }
    }
}
