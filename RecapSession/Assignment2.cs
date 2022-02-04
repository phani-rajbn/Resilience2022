using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapSession
{
    class Shape
    {
        public bool FillStatus { get; set; }
        public string BackColor { get; set; }
        public override string ToString()
        {
            string oldValue = "Shape ";
            string value = "";
            if (FillStatus == true) value = "filled"; else value = "Not Filled";
            oldValue += $"| A Shape  with color {BackColor} and {value}";
            return oldValue;
        }
    }

    class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public override string ToString()
        {
            string baseValue = base.ToString();
            string value = $"Rectange|A Rectange with width = {Width} and Length = {Length} and is a subclass of {this.GetType().BaseType.Name}";
            return value;
        }
    }
    internal class Assignment2
    {
        static void Main(string[] args)
        {
            Shape xxx = new Shape { BackColor ="Yellow", FillStatus = true };
            Console.WriteLine(xxx);

            xxx = new Rectangle { Length = 200, Width = 300 };
            Console.WriteLine(xxx);
        }
    }
}
