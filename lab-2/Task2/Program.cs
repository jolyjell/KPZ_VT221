using System;

namespace AbstractFactoryPattern
{
    public abstract class Laptop
    {
        public abstract void ShowDetails();
    }

    public abstract class Smartphone
    {
        public abstract void ShowDetails();
    }

    public class IProneLaptop : Laptop
    {
        public override void ShowDetails()
        {
            Console.WriteLine("IProne Laptop");
        }
    }

    public class IProneSmartphone : Smartphone
    {
        public override void ShowDetails()
        {
            Console.WriteLine("IProne Smartphone");
        }
    }

    public class KiaomiLaptop : Laptop
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Kiaomi Laptop");
        }
    }

    public class KiaomiSmartphone : Smartphone
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Kiaomi Smartphone");
        }
    }

    public class BalaxyLaptop : Laptop
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Balaxy Laptop");
        }
    }

    public class BalaxySmartphone : Smartphone
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Balaxy Smartphone");
        }
    }

    public abstract class TechFactory
    {
        public abstract Laptop CreateLaptop();
        public abstract Smartphone CreateSmartphone();
    }

    public class IProneFactory : TechFactory
    {
        public override Laptop CreateLaptop()
        {
            return new IProneLaptop();
        }

        public override Smartphone CreateSmartphone()
        {
            return new IProneSmartphone();
        }
    }

    public class KiaomiFactory : TechFactory
    {
        public override Laptop CreateLaptop()
        {
            return new KiaomiLaptop();
        }

        public override Smartphone CreateSmartphone()
        {
            return new KiaomiSmartphone();
        }
    }

    public class BalaxyFactory : TechFactory
    {
        public override Laptop CreateLaptop()
        {
            return new BalaxyLaptop();
        }

        public override Smartphone CreateSmartphone()
        {
            return new BalaxySmartphone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TechFactory iproneFactory = new IProneFactory();
            TechFactory kiaomiFactory = new KiaomiFactory();
            TechFactory balaxyFactory = new BalaxyFactory();

            Laptop iproneLaptop = iproneFactory.CreateLaptop();
            Smartphone iproneSmartphone = iproneFactory.CreateSmartphone();

            Laptop kiaomiLaptop = kiaomiFactory.CreateLaptop();
            Smartphone kiaomiSmartphone = kiaomiFactory.CreateSmartphone();

            Laptop balaxyLaptop = balaxyFactory.CreateLaptop();
            Smartphone balaxySmartphone = balaxyFactory.CreateSmartphone();

            iproneLaptop.ShowDetails();
            iproneSmartphone.ShowDetails();

            kiaomiLaptop.ShowDetails();
            kiaomiSmartphone.ShowDetails();

            balaxyLaptop.ShowDetails();
            balaxySmartphone.ShowDetails();
        }
    }
}
