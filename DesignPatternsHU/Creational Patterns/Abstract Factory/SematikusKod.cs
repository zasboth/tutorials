using System;

namespace DoFactory.GangOfFour.Abstract.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Abstract Factory Design Pattern.
    /// </summary>

    class MainApp
    {
        /// <summary>
        /// Belépési pont a console alkalmazásba.
        /// </summary>

        public static void Main()
        {
            // Abstract factory #1

            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Az 'AbstractFactory' abstract osztálya
    /// </summary>

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }


    /// <summary>
    /// A 'ConcreteFactory1' osztály
    /// </summary>

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    /// <summary>
    /// A 'ConcreteFactory2' osztály
    /// </summary>

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    /// <summary>
    /// Az 'AbstractProductA' abstract osztály
    /// </summary>

    abstract class AbstractProductA
    {
    }

    /// <summary>
    /// Az 'AbstractProductB' abstract osztály
    /// </summary>

    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }


    /// <summary>
    /// A 'ProductA1' osztály
    /// </summary>

    class ProductA1 : AbstractProductA
    {
    }

    /// <summary>
    /// A 'ProductB1' osztály
    /// </summary>

    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    /// <summary>
    /// A 'ProductA2' osztály
    /// </summary>

    class ProductA2 : AbstractProductA
    {
    }

    /// <summary>
    /// A 'ProductB2' osztály
    /// </summary>

    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    /// <summary>
    /// A 'Client' osztály. Együtműködési környezet a termékekhez.
    /// </summary>

    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;


        public Client(AbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}
