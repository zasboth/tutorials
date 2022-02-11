using System;

namespace DoFactory.GangOfFour.Abstract.RealWorld
{
    /// <summary>
    /// MainApp startup ostály Real-World számára
    /// Abstract Factory Design Pattern.
    /// </summary>

    class MainApp
    {
        /// <summary>
        /// Belépési pont console alkalmazásba.
        /// </summary>

        public static void Main()
        {
            // Létrehozza és futtatja az Afrika állatvilágát

            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Létrehozza és futtatja Amerika allatvilágát

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();


            Console.ReadKey();
        }
    }


    /// <summary>
    /// Maga az 'AbstractFactory' abstract osztálya
    /// </summary>

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// Leszármaztatott osztály Afrika
    /// </summary>

    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    /// Leszármaztatott osztály Amerika
    /// </summary>

    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    /// <summary>
    /// Az 'AbstractProductA' abstract osztály
    /// </summary>

    abstract class Herbivore
    {
    }

    /// <summary>
    /// Az 'AbstractProductB' abstract osztály
    /// </summary>

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// A 'ProductA1' osztály gnú
    /// </summary>

    class Wildebeest : Herbivore
    {
    }

    /// <summary>
    /// A 'ProductB1' osztály oroszlán
    /// </summary>

    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Gnút eszik

            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// A 'ProductA2' osztály bölény
    /// </summary>

    class Bison : Herbivore
    {
    }

    /// <summary>
    /// A 'ProductB2' osztály farkas
    /// </summary>

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // A farkas bölényt eszik

            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// A 'Client' osztály állatvilág 
    /// </summary>

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
