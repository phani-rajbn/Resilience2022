using System;
using System.Threading;
namespace SampleConApp_Day16
{
    delegate void InvokeAlarm(); 
    class Clock
    {
        DateTime alarmTime;
        public event InvokeAlarm OnAlarmTime; //Events are instances of Delegates
        public Clock(DateTime time)
        {
            alarmTime = time;
        }
        public void Display()
        {
            do
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.Clear();
                if(alarmTime.ToShortTimeString() == DateTime.Now.ToShortTimeString())
                {
                    if (OnAlarmTime != null)//Possible if the event handler is not created.
                        OnAlarmTime();
                }
            } while (true);
        }
    }
    internal class EventsDemo
    {
        static void Main(string[] args)
        {
            Clock clk = new Clock(DateTime.Now.AddMinutes(1));
            //clk.OnAlarmTime += new InvokeAlarm(teaTime); //+= operator is used to set an handler to the event, old syntax
            clk.OnAlarmTime += () =>
            {
                Console.WriteLine("Time to take a break for tea!!!"); //new way using LAMBDA EXPRESSION
                Console.Beep();
            };
            clk.Display();
        }
    }
}
