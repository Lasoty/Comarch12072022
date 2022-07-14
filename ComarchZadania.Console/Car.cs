using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchZadania.Console
{
    public enum Color
    {
        Red = 1,
        Green = 2,
        Blue = 4,
    }

    public interface IAuto
    {
        Color BodyColor { get; set; }
        void SetColor(Color color);
        string GetCarInfo();
    }

    public delegate int ZatankujDelegate(int actualState, int maxState);

    public abstract class Auto
    {
        public void RunEnginge()
        {
            System.Console.WriteLine();
        }

        public abstract void StopEnginge();
    }

    public class Car : Auto, IAuto
    {
        public string Marka; // Pole klasy
        private string model;
        protected int fuelState;

        public string Model //Full property
        {
            get
            {
                System.Console.WriteLine("Odczyt " + model);
                return model;
            }
            set
            {
                System.Console.WriteLine("Zapis " + model);
                model = value;
            }
        }

        public Color BodyColor { get; set; } // Short property

        //Konstruktor
        public Car(string marka, string model, Color bodyColor)
        {
            Marka = marka;
            Model = model;
            BodyColor = bodyColor;
        }

        public Car()
        {

        }

        public string GetCarInfo()
        {
            // this // instancja siebie samego
            return $"Marka: {Marka}, Model: {Model}";
        }

        public virtual void Zatankuj(ZatankujDelegate zatankuj)
        {
            fuelState = zatankuj(fuelState, 80);

            FuelStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public override void StopEnginge()
        {
            System.Console.WriteLine("Silnik wyłączony");
        }

        public void SetColor(Color color)
        {
            throw new NotImplementedException();
        }

        public event EventHandler FuelStateChanged;
    }

    public class Truck : Car
    {
        public int Capacity { get; set; }

        public override void Zatankuj(ZatankujDelegate zatankuj)
        {
            fuelState = zatankuj(fuelState, 250);

            FuelStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler FuelStateChanged;

    }

    class CarManager
    {
        public void AddCar()
        {
            Car car = new Car("Audi", "A6", Color.Red);
            car.FuelStateChanged += OnFuelStateChanged;
            car.Marka = "dsd";

            var model = car.Model;
            car.Model = model;
            car.BodyColor = Color.Red;
            TankujAuto(car);

            Truck truck = new Truck();
            TankujAuto(truck);

            Auto auto = new Car();
            Auto auto2 = new Truck();

            CosTam(car);
            CosTam(truck);
        }

        public void TankujAuto(Car car)
        {
            car.Zatankuj(TankujNaBp);
        }

        public void CosTam(IAuto auto)
        {
            var info = auto.GetCarInfo();
        }

        private void OnFuelStateChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine("Zatankowano auto.");
        }

        private int TankujNaBp(int actualState, int maxState)
        {
            return maxState - actualState;
        }
    }
}
