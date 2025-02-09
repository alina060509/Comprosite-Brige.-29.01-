using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brige
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine gasolineEngine = new GasolineEngine();
            Engine electricEngine = new ElectricEngine();

            Vehicle carWithGasoline = new Car(gasolineEngine);
            Vehicle truckWithElectric = new Truck(electricEngine);
            Console.WriteLine(carWithGasoline.Drive());
            Console.WriteLine(truckWithElectric.Drive());
        }
    }
    public interface Engine
    {
        void Start();
        void Worth();

    }
    public class GasolineEngine : Engine
    {
        public void Start()
        {
            Console.WriteLine("Бензиновый двигатель запущен");

        }
        public void Worth()
        {
            Console.WriteLine("Бензиновый двигатель выключен");
        }
    }

    public class ElectricEngine : Engine
    {
        public void Start()
        {
            Console.WriteLine("Электрический двигатель запущен");
        }
        public void Worth()
        {
            Console.WriteLine("Электрический двигатель выключен");
        }
    }
    public abstract class Vehicle
    {
        protected Engine _engine;

        public Vehicle(Engine engine)
        {
            _engine = engine;
        }
        public abstract string Drive();
    }

    public class Car : Vehicle
    {
        public Car(Engine engine) : base(engine) { }

        public override string Drive()
        {
            return $"Автомобиль с {_engine.Start()} едет.";
        }
    }


    public class Truck : Vehicle
    {
        public Truck(Engine engine) : base(engine) { }

        public override string Drive()
        {
            return $"Грузовик с {_engine.Start()} перевозит груз.";
        }
    }
}
