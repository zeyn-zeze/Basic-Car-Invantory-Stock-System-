
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Programming_Lab
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<TrimPackage> Packages { get; set; }
        public int Year { get; set; }

        public Car(int carId, string brand, string model, int year)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            Packages = new List<TrimPackage>();
        }

        // This function lists the available cars from a given list and allows the user to select a car by its ID.
        public static Car List_Cars(List<Car> cars)
        {
            // Displaying the list of cars in the inventory
            Console.WriteLine("\n Car Lists : \n");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarId}. {car.Brand} - {car.Model} - {car.Year}");
            }

            // Asking the user to choose a car by its ID
            Console.WriteLine("Which car do you want to list?");
            int selected_car = Convert.ToInt16(Console.ReadLine());

            // Finding the selected car by its ID in the provided list
            Car selected = cars.Find(x => x.CarId == selected_car);
            return selected;
        }


        // This function lists the available packages for a given car and allows the user to select a package by its ID.
        public static TrimPackage List_Packages(Car car)
        {
            // Displaying the list of packages available for the given car
            Console.WriteLine("\n Package List: \n");
            foreach (var pkg in car.Packages)
            {
                Console.WriteLine($"{pkg.PackageId}. {pkg.Name}");
            }

            // Asking the user to choose a package by its ID
            Console.WriteLine("Which package do you want to list?\n");
            int selected = Convert.ToInt16(Console.ReadLine());

            // Finding the selected package by its ID in the car's available packages
            TrimPackage package = car.Packages.Find(x => x.PackageId == selected);

            return package; // Returning the selected package
        }


        // This function lists the available spare parts for a specific car and package combination.
        public static void ListSpareParts(Car car, TrimPackage package)
        {
            // Displays the available spare parts for the given car and package
            Console.WriteLine($"\nAvailable Spare Parts for {car.Brand} {car.Model} {package.Name}:");
            foreach (var part in package.SpareParts)
            {
                Console.WriteLine($"{part.PartId}. {part.SparePartName} - Quantity : {part.InventoryCount}");
            }
        }


        public static List<Car> CreateCarInventory()
        {
            List<Car> Cars = new List<Car>();

            // INFO OF THE VEHICLE WITH CAR ID = 1
            Car car = new Car(1, "Hyundai", "Sonata", 2023);
            TrimPackage package = new TrimPackage(car.CarId, 1, "Select");
            package.SpareParts.Add(new SparePart(car.CarId,  package.PackageId, 1, "Brake Pad", 15));
            package.SpareParts.Add(new SparePart(car.CarId,  package.PackageId, 2, "Air Filter", 18));
            package.SpareParts.Add(new SparePart(car.CarId,  package.PackageId, 3, "Headlight Lamp", 20));
            package.SpareParts.Add(new SparePart(car.CarId,  package.PackageId, 4, "Steering Pump", 12));
            package.SpareParts.Add(new SparePart(car.CarId,  package.PackageId, 5, "Starter Motor", 19));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Shaft", 30));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 2, "Style");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Front Bumper", 17));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Filter", 18));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Lamp", 20));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Steering Pump", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Spark Plug", 24));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Shock absorber", 15));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Accumulator", 25));
            car.Packages.Add(package);
            Cars.Add(car);

            //INFO OF THE VEHICLE WITH CAR ID = 2
            car = new Car(2, "Kia", "Optima", 2019);
            package = new TrimPackage(car.CarId, 3, "LX");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Front Bumper", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Accumulator", 20));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Water Pump", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Exhaust Muffler", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Brake Pads", 19));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Wiper Blades", 5));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 4, "SX");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Headlight Lamp", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Spark Plug", 20));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Water Pump", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Shock absorber", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Brake Caliper", 14));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Front Bumper", 16));
            car.Packages.Add(package);
            Cars.Add(car);

            //INFO OF THE VEHICLE WITH CAR ID = 3
            car = new Car(3, "Toyota", "Corolla", 2023);
            package = new TrimPackage(car.CarId, 5, "Vison");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Door mirror", 13));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Back Headlight Lamp", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Oil Filter", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Air Filter", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Water Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Jant", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Steering Pump", 17));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 6, "Dream");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Front brake pads", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Conditioning Compressor", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Oil Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Air Filter", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Water Pump", 11));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Power Steering Pump", 10));
            car.Packages.Add(package);
            Cars.Add(car);

            // INFO OF THE VEHICLE WITH CAR ID = 4
            car = new Car(4, "Honda", "Civic", 2020);
            package = new TrimPackage(car.CarId, 7, "Sedan");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Brake Pad", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Filter", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Lamp", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Steering Pump", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Starter Motor", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Radiator", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Engine Oil", 15));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Wiper Blades", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Fuel Filter", 8));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 8, "Elegant");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Brake rotors", 20));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Brake calipers", 28));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Air filters", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Serpentine belt", 15));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Clutch kit", 17));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Brake fluid", 19));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Side mirrors", 25));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Oxygen sensors", 26));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Wiper Blades", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 11, "Fuel Filter", 16));
            car.Packages.Add(package);
            Cars.Add(car);

            //INFO OF THE VEHICLE WITH CAR ID = 5
            car = new Car(5, "Ford", "Focus", 2023);
            package = new TrimPackage(car.CarId, 9, "Titanium");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,1, "Brake Disc", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,2, "Air Conditioning Compressor", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,3, "Fuel Pump", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,4, "Radiator Hose", 15));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,5, "Ignition Coil", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,6 ,"Timing Belt", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,7 ,"Wheel Bearing", 11));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,8 ,"Shock Absorber", 14));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,9 ,"Battery", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId,10, "Thermostat", 7));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 10, "ActiveX");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,1, "Spark Plug", 11));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,2,"Air Conditioning Compressor", 13));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,3,"Fuel Pump", 11));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,4,"Radiator Hose", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,5,"Ignition Coil", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,6, "Headlight Assembly", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,7,"Wheel Bearing", 11));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,8,"Shock Absorber", 14));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,9,"Battery", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,10,"Thermostat", 7));
            car.Packages.Add(package);
            Cars.Add(car);

            //INFO OF THE VEHICLE WITH CAR ID = 6
            car = new Car(6, "Volkswagen", "Jetta", 2017);
            package = new TrimPackage(car.CarId, 11, "TrendLine");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,1 ,"Brake Caliper", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,2 ,"Air Filter", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,3 ,"Headlight Assembly", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,4 ,"Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,5 ,"Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,6 ,"Radiator", 9));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,7 ,"Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,8, "Fuel Pump", 6));
            car.Packages.Add(package);
            

            package = new TrimPackage(car.CarId, 12, "ComfortLine");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,1, "Engine Mounts", 19));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,2,"Air Filter", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,3 ,"Headlight Assembly", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,4 ,"Power Steering Pump", 13));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,5 ,"Starter Motor", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,6 ,"Radiator", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,7 ,"Brake Caliper", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId,8, "Fuel Pump", 16));
            car.Packages.Add(package);
            Cars.Add(car);


            // INFO OF THE VEHICLE WITH CAR ID = 7
            car = new Car(7, "BMW", "3 Serisi", 2023);
            package = new TrimPackage(car.CarId, 13, "LuxuryLine");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Brake Pads", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Bulbs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Engine Oil", 15));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Wiper Blades", 7));
            car.Packages.Add(package);


            package = new TrimPackage(car.CarId, 14, "SportLine");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 1, "Brake Pads", 12));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 2, "Air Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 3, "Headlight Bulbs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 6, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 9, "Engine Oil", 15));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 10, "Wiper Blades", 7));
            car.Packages.Add(package);
            Cars.Add(car);

            // INFO OF THE VEHICLE WITH CAR ID = 8
            car = new Car(8, "Mercedes-Benz", "C Serisi", 2020);
            package = new TrimPackage(car.CarId, 15, "AMG");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 1, "Brake Discs", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 2, "Air Filter", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 3, "Headlight Assembly", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 6, "Radiator", 9));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 9, "Engine Oil", 12));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 10, "Wiper Blades", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 11, "Transmission Fluid", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 12, "Battery", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 13, "Brake Pads", 9));
            car.Packages.Add(package);


            package = new TrimPackage(car.CarId, 16, "Avantgarde");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Brake Discs", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Filter", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Assembly", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Radiator", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Engine Oil", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Wiper Blades", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 11, "Transmission Fluid", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 12, "Battery", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 13, "Brake Pads", 9));
            car.Packages.Add(package);
            Cars.Add(car);

            // INFO OF THE VEHICLE WITH CAR ID = 9

            car = new Car(9, "Audi", "A3", 2020);
            package = new TrimPackage(car.CarId, 17, "Sportback");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 1, "Brake Pads", 12));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 2, "Air Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 3, "Headlight Bulbs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 6, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 9, "Engine Oil", 14));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 10, "Wiper Blades", 7));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 18, "Sedan");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Brake Pads", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Air Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Bulbs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Engine Oil", 14));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Wiper Blades", 7));
            car.Packages.Add(package);
            Cars.Add(car);


            // INFO OF THE VEHICLE WITH CAR ID = 10
            car = new Car(10, "Chevrolet", "Cruze", 2012);
            package = new TrimPackage(car.CarId, 19, "LS");
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 1, "Brake Pads", 12));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 2, "Air Filter", 9));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 3, "Headlight Bulbs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 4, "Power Steering Pump", 7));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 6, "Radiator", 10));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 7, "Spark Plugs", 8));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 8, "Fuel Pump", 6));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 9, "Engine Oil", 14));
            package.SpareParts.Add(new SparePart(car.CarId,package.PackageId, 10, "Wiper Blades", 7));
            car.Packages.Add(package);

            package = new TrimPackage(car.CarId, 20, "LT");
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 1, "Radiator", 12));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 2, "Engine Oil", 7));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 3, "Headlight Bulbs", 6));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 4, "Power Steering Pump", 17));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 5, "Starter Motor", 5));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 6, "Brake Pads", 9));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 7, "Spark Plugs", 13));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 8, "Fuel Pump", 16));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 9, "Air Filter", 14));
            package.SpareParts.Add(new SparePart(car.CarId, package.PackageId, 10, "Wiper Blades", 10));
            car.Packages.Add(package);
            Cars.Add(car);
            
            return Cars;
        }
    }


    // This class represents a trim package for a car, containing information about the package 
    public class TrimPackage
    {
        // Constructor to initialize a TrimPackage object with specified parameters
        public TrimPackage(int carId, int packageId, string name)
        {
            CarId = carId; // Initializes the CarId property
            PackageId = packageId; // Initializes the PackageId property
            Name = name; // Initializes the Name property
            SpareParts = new List<SparePart>(); // Initializes the SpareParts list
        }

        // CarId property representing the ID of the car associated with the package
        public int CarId { get; set; }

        // PackageId property representing the ID of the package
        public int PackageId { get; set; }

        // Name property representing the name of the package
        public string Name { get; set; }

        // SpareParts property representing the list of spare parts associated with the package
        public List<SparePart> SpareParts { get; set; }
    }


    // This class represents a spare part, containing information about the part 
    public class SparePart
    {
        // CarId property representing the ID of the car 
        public int CarId { get; set; }

        // PackageId property representing the ID of the package 
        public int PackageId { get; set; }

        // PartId property representing the ID of the spare part
        public int PartId { get; set; }

        // SparePartName property representing the name of the spare part
        public string SparePartName { get; set; }

        // InventoryCount property representing the count of the spare part available in inventory
        public int InventoryCount { get; set; }

        // Constructor to initialize a SparePart object with specified parameters
        public SparePart(int carId, int packageId, int partId, string sparePartName, int inventoryCount)
        {
            CarId = carId; // Initializes the CarId property
            PackageId = packageId; // Initializes the PackageId property
            PartId = partId; // Initializes the PartId property
            SparePartName = sparePartName; // Initializes the SparePartName property
            InventoryCount = inventoryCount; // Initializes the InventoryCount property
        }
    }


    // This class represents a spare part that is added to a cart, inheriting properties from the SparePart class.
    public class SparePartOnCart : SparePart
    {
        // DealerApprove property represents whether the spare part on the cart is approved by the dealer
        public bool? DealerApprove = null;

        // Constructor to create a SparePartOnCart object based on a given SparePart object
        public SparePartOnCart(SparePart part) : base(part.CarId, part.PackageId, part.PartId, part.SparePartName, part.InventoryCount)
        {
            DealerApprove = null; // Initializes DealerApprove property to null
        }
    }

}
