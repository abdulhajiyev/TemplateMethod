using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            var visitor1 = new DoctorVisitor("James");
            school.PerformOperation(visitor1);

            Console.WriteLine();

            var visitor2 = new SalesmanVisitor("John");
            school.PerformOperation(visitor2);
            Console.Read();
        }
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class Kid : IElement
    {
        public string KidName { get; set; }

        public Kid(string name)
        {
            KidName = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(IElement element);
    }

    public class DoctorVisitor : IVisitor
    {
        public string Name { get; set; }

        public DoctorVisitor(string name)
        {
            Name = name;
        }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.KidName}");
        }
    }

    class SalesmanVisitor : IVisitor
    {
        public string Name { get; set; }

        public SalesmanVisitor(string name)
        {
            Name = name;
        }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Salesman: {Name} gave the school bag to the child: {kid.KidName}");
        }
    }

    public class School
    {
        private static List<IElement> elements;

        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Sara"),
                new Kid("Pam")
            };
        }

        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements)
            {
                kid.Accept(visitor);
            }
        }
    }
}
