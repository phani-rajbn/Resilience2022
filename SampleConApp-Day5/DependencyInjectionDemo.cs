using System;

namespace SampleConApp_Day4
{
    class Infotainment
    {
        public Infotainment(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public void Play()
        {
            Console.WriteLine($"The {Name} is playing");
        }
    }
    class Car
    {
        public Car()
        {
            Entertainment = new Infotainment("HONDA");
        }
        public Car(Infotainment info)
        {
            Entertainment = info;
        }

        public Infotainment Entertainment { get; set; }//HAS-A Relation. Every Car has a Infotainment..
        public void Run()
        {
            Console.WriteLine("The Car is Running!");
            Entertainment.Play();
        }
    }
    internal class DependencyInjectionDemo
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Entertainment = new Infotainment("SONY");//Property Injection
            car.Run();
        }
    }
}
