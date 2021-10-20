using System;

namespace TemplateMethod
{
    public abstract class HouseTemplate
    {
        public void BuildHouse()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
            Console.WriteLine("House is built");
        }

        protected abstract void BuildFoundation();
        protected abstract void BuildPillars();
        protected abstract void BuildWalls();
        protected abstract void BuildWindows();
    }

    public class ConcreteHouse : HouseTemplate
    {
        protected override void BuildFoundation() => Console.WriteLine("Building concrete foundation");

        protected override void BuildPillars() => Console.WriteLine("Building concrete pillars");

        protected override void BuildWalls() => Console.WriteLine("Building concrete walls");

        protected override void BuildWindows() => Console.WriteLine("Building concrete windows");
    }

    public class WoodenHouse : HouseTemplate
    {
        protected override void BuildFoundation() => Console.WriteLine("Building wood foundation");

        protected override void BuildPillars() => Console.WriteLine("Building wood pillars");

        protected override void BuildWalls() => Console.WriteLine("Building wood walls");

        protected override void BuildWindows() => Console.WriteLine("Building wood windows");
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build a Concrete House\n");
            HouseTemplate houseTemplate = new ConcreteHouse();
            // calling the template method
            houseTemplate.BuildHouse();
            Console.WriteLine();

            Console.WriteLine("Build a Wooden House\n");
            houseTemplate = new WoodenHouse();
            // calling the template method
            houseTemplate.BuildHouse();
            Console.Read();
        }
    }
}
