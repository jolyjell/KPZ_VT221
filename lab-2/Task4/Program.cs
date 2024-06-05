using System;
using System.Collections.Generic;

namespace PrototypePattern
{
    public class Virus : ICloneable
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string species, double weight, int age)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
            Children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public object Clone()
        {
            Virus clone = (Virus)this.MemberwiseClone();
            clone.Children = new List<Virus>();

            foreach (var child in Children)
            {
                clone.Children.Add((Virus)child.Clone());
            }

            return clone;
        }

        public void Display(int generation = 0)
        {
            string indent = new string(' ', generation * 2);
            Console.WriteLine($"{indent}Ім'я: {Name}, Вид: {Species}, Вага: {Weight}, Вік: {Age}");
            foreach (var child in Children)
            {
                child.Display(generation + 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Virus parentVirus = new Virus("Батько", "Вид1", 2.5, 5);

            Virus childVirus1 = new Virus("Дитина1", "Вид1", 1.2, 3);
            Virus childVirus2 = new Virus("Дитина2", "Вид1", 1.3, 4);

            parentVirus.AddChild(childVirus1);
            parentVirus.AddChild(childVirus2);

            Virus grandChildVirus1 = new Virus("Онук1", "Вид1", 0.6, 1);
            Virus grandChildVirus2 = new Virus("Онук2", "Вид1", 0.7, 2);

            childVirus1.AddChild(grandChildVirus1);
            childVirus2.AddChild(grandChildVirus2);

            Virus clonedParentVirus = (Virus)parentVirus.Clone();

            Console.WriteLine("Оригінальна сім'я віруса:");
            parentVirus.Display();

            Console.WriteLine("\nклонована сім'я віруса:");
            clonedParentVirus.Display();
        }
    }
}