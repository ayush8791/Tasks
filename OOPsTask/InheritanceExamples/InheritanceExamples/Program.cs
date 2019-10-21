using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples
{
    public class Vehicle
    {
        public enum vehicleType {
            small,
            medium,
            large

        }
        public int wheels;
        public int seatingCapacity;
        public bool roof;
        public int vehicleTypeId;

        public bool ignition()
        {

            Console.WriteLine("Igniting the Engine..........done!");
            return true;
        }
        public bool engineStop()
        {
            Console.WriteLine("Cutting Fuel Supply to stop engine....done!");
            return true;
        }

    }

    public class Car : Vehicle {
        public enum carType { 
        sedan,
        compact,
        mini,
        suv

        }
        public int fuelCapacity = 10;
        public int carTypeId;
        public int engineCC;
        public bool ac;

        public bool switchOnAc()
        {
            ac = true;
            Console.WriteLine("Air Conditioner is switched On");
            return true;
        }
        public bool switchOffAc()
        {
            ac = false;
            Console.WriteLine("Air Conditioner is switched off");
            return true;
        }



    }

    class Honda : Car {

        public static string manufacturer = "Honda";
        public string model = "Civic";
        public Honda()
        {
            this.fuelCapacity = 20;
            this.engineCC = 1000;
            this.carTypeId=(int)carType.sedan;
            this.roof = true;
            this.seatingCapacity = 5;
            this.vehicleTypeId = (int)vehicleType.medium;
        
        }
        public void printCarInfo()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Type is " + vehicleTypeId);
            Console.WriteLine("Car Type is " + carTypeId);
            Console.WriteLine("Manufacturer is " +manufacturer);
            Console.WriteLine("Car Model is "+model);
            Console.WriteLine(" Engine capacity is "+engineCC);
            Console.WriteLine("Seating Capacity is "+seatingCapacity);




        }
        public static void Main(string[] ars)
        {
            Honda civic = new Honda();
            Console.WriteLine("Following are car Information");
            civic.printCarInfo();

            Console.WriteLine("\n\n Attempting to start car");
            civic.ignition();
            Console.WriteLine("Attempting to switch on AC");
            civic.switchOnAc();
            Console.WriteLine("Attempting to switch off AC");
            civic.switchOffAc();
            Console.WriteLine("Shutting Down Engine !");
            civic.engineStop();

            Console.ReadLine();
        }
    
    
    }
}
