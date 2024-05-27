using System;
using System.Collections.Generic;

abstract class Subscription
{
    public abstract float MonthlyFee { get; }
    public abstract int MinimumSubscriptionPeriod { get; }
    public abstract List<string> Channels { get; }
    public abstract List<string> Features { get; }

    public void GetDetails()
    {
        Console.WriteLine($"Підписка типу {GetType().Name}:");
        Console.WriteLine($"Плата: {MonthlyFee} USD");
        Console.WriteLine($"Мінімальний період підписки: {MinimumSubscriptionPeriod} місяць(ці)");
        Console.WriteLine("Канали: " + string.Join(", ", Channels));
        Console.WriteLine("Інші можливості: " + string.Join(", ", Features));
    }
}

class DomesticSubscription : Subscription
{
    public override float MonthlyFee => 9.99f;
    public override int MinimumSubscriptionPeriod => 1;
    public override List<string> Channels => new List<string> { "Канал1", "Канал2", "Канал3" };
    public override List<string> Features => new List<string> { "звичайна якість" };
}

class EducationalSubscription : Subscription
{
    public override float MonthlyFee => 14.99f;
    public override int MinimumSubscriptionPeriod => 1;
    public override List<string> Channels => new List<string> { "Навчальни1", "Навчальни2", "Навчальни3", "Навчальни4" };
    public override List<string> Features => new List<string> { "стандартна якість", "навчальний контент" };
}

class PremiumSubscription : Subscription
{
    public override float MonthlyFee => 19.99f;
    public override int MinimumSubscriptionPeriod => 1;
    public override List<string> Channels => new List<string> { "Канал1", "Канал2", "Канал3", "Канал4", "Канал5" };
    public override List<string> Features => new List<string> { "висока якість", "без реклами" };
}

abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription();
}

class DomesticSubscriptionFactory : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}

class EducationalSubscriptionFactory : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}

class PremiumSubscriptionFactory : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}

interface ISubscriptionCreator
{
    Subscription CreateSubscription(SubscriptionFactory factory);
}

class WebSite : ISubscriptionCreator
{
    public Subscription CreateSubscription(SubscriptionFactory factory)
    {
        Console.WriteLine("створення підписки через WebSite...");
        return factory.CreateSubscription();
    }
}

class MobileApp : ISubscriptionCreator
{
    public Subscription CreateSubscription(SubscriptionFactory factory)
    {
        Console.WriteLine("створення підписки через MobileApp...");
        return factory.CreateSubscription();
    }
}

class ManagerCall : ISubscriptionCreator
{
    public Subscription CreateSubscription(SubscriptionFactory factory)
    {
        Console.WriteLine("створення підписки через ManagerCall...");
        return factory.CreateSubscription();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Використання WebSite для створення підписок
        ISubscriptionCreator webSiteCreator = new WebSite();
        SubscriptionFactory domesticFactory = new DomesticSubscriptionFactory();
        Subscription domesticSubscription = webSiteCreator.CreateSubscription(domesticFactory);
        domesticSubscription.GetDetails();
        Console.WriteLine();

        // Використання MobileApp для створення підписок
        ISubscriptionCreator mobileAppCreator = new MobileApp();
        SubscriptionFactory educationalFactory = new EducationalSubscriptionFactory();
        Subscription educationalSubscription = mobileAppCreator.CreateSubscription(educationalFactory);
        educationalSubscription.GetDetails();
        Console.WriteLine();

        // Використання ManagerCall для створення підписок
        ISubscriptionCreator managerCallCreator = new ManagerCall();
        SubscriptionFactory premiumFactory = new PremiumSubscriptionFactory();
        Subscription premiumSubscription = managerCallCreator.CreateSubscription(premiumFactory);
        premiumSubscription.GetDetails();
    }
}
