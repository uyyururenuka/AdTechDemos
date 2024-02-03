namespace IDELanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide=new IDE();
            CSharp cs=new CSharp();
            Java java=new Java();
            CLang cLang=new CLang();
            Typescript typescript=new Typescript();
            //ObjectOriented objectOriented=new ObjectOriented();
            //ide.CS=cs;
            //ide.Java=java;
            //ide.C=cLang;
            ide.Languages.Add(cs);
            ide.Languages.Add (java);
            ide.Languages.Add (cLang);
            ide.Languages.Add (typescript);

            ide.work();
        }
    }

    //new feature,new code don't/minimize the modify the existing code
    //separate what repeats from what stays constant
    //code should be ideatic proof

    class IDE  //SRP Single responsibility principle.   One more property OCP-Open Close principle\
               // this IDE Program to Interface/Abstraction not to implimentation
    {
        //public CSharp CS { get; set; }
        //public Java Java { get; set; }
        //public CLang C {  get; set; }

        public List<ILanguage> Languages {  get; set; }= new List<ILanguage>();

        public void work()
        {
            foreach (var lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine(lang.GetParadiagm());
            }

            

        }

    }

    interface ILanguage//interface defines "what?" it means what is the all languages class shoul do
                      //And all the methods in the interface by default are public and virtual and also abstract
    {
        string GetName();
        string GetUnit();
        string GetParadiagm();
    }

    abstract class ObjectOriented : ILanguage
    {
        public string GetUnit() { return "Class"; }
        public string GetParadiagm() { return "Object Oriented"; }

        abstract public string GetName();
        
    }
   abstract  class Procedural : ILanguage
    {
        public string GetUnit() { return "Function"; }
        public string GetParadiagm() { return "Procedural"; }

        abstract public string GetName();
        
    }
    class CSharp : ObjectOriented //Inheritance /IS-A/Realization
    {
        public override string GetName() { return "CSharp(C#)"; }
        

    }
    class Java : ObjectOriented
    {
        public override string GetName() { return "Java"; }
       
    }
    class CLang : Procedural
    {
        public override string GetName() { return "C Language"; }
        
    }
    class Typescript : ObjectOriented
    {
        public override string GetName() { return "Typescript Language"; }
        
    }
}
