using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public class Character
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Deeds { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Ім'я: {Name}, Ріст: {Height}, Тіло: {Build}, Колір волосся: {HairColor}, Колір очей: {EyeColor}, Інвентар: {string.Join(", ", Inventory)}, Заслуги: {string.Join(", ", Deeds)}";
        }
    }
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(double height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder AddInventoryItem(string item);
        ICharacterBuilder AddDeed(string deed);
        Character Build();
    }

    public class HeroBuilder : ICharacterBuilder
    {
        private Character character;

        public HeroBuilder()
        {
            character = new Character();
        }

        public ICharacterBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(double height)
        {
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            character.Deeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character character;

        public EnemyBuilder()
        {
            character = new Character();
        }

        public ICharacterBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(double height)
        {
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddDeed(string deed)
        {
            character.Deeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }

    public class Director
    {
        public Character ConstructHero(ICharacterBuilder builder)
        {
            return builder
                .SetName("Герой Архілес")
                .SetHeight(180)
                .SetBuild("Атлет")
                .SetHairColor("Чорний")
                .SetEyeColor("Blue")
                .AddInventoryItem("Меч")
                .AddInventoryItem("Щит")
                .AddDeed("Врятував село")
                .Build();
        }

        public Character ConstructEnemy(ICharacterBuilder builder)
        {
            return builder
                .SetName("Негідник Арлонг")
                .SetHeight(190)
                .SetBuild("Качок")
                .SetHairColor("Чорний")
                .SetEyeColor("Голубий")
                .AddInventoryItem("Бойові крабики")
                .AddInventoryItem("Луфі")
                .AddDeed("Намагався вбити Намі")
                .Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            HeroBuilder heroBuilder = new HeroBuilder();
            Character hero = director.ConstructHero(heroBuilder);
            Console.WriteLine("Hero:");
            Console.WriteLine(hero);

            EnemyBuilder enemyBuilder = new EnemyBuilder();
            Character enemy = director.ConstructEnemy(enemyBuilder);
            Console.WriteLine("\nEnemy:");
            Console.WriteLine(enemy);
        }
    }
}
