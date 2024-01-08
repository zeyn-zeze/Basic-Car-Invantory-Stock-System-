
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Lab
{
    public class User
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        // User_name validation
        public static bool IsUserNameValid(string userName)
        {
            if (userName.Length < 5 || userName.Length > 20) // username should contain a minimum of 5 characters and a maximum of 20 characters.
            {
                return false;
            }

            foreach (char c in userName)
            {
                if (!char.IsLetterOrDigit(c)) //Should consist of only letters or digits.
                {
                    return false;
                }
            }

            // First character letter check
            if (!char.IsLetter(userName[0])) //The first character should be a letter.
            {
                return false;
            }

            return true; // Return true if all checks passed
        }


        // is or not speacial character there due to we dont have avaliable function
        public static bool HasSpecialCharacter(char c)
        {
            string specialc = "!@#$%&*-+";
            return specialc.Contains(c);
        }

        //Password validation
         public static bool IsPasswordValid(string password)
        {
            if (password.Length < 8 || password.Length > 20)
            { return false; }

            if (!password.Any(char.IsDigit)) { return false; }
            if (!password.Any(char.IsUpper)) { return false; }
            if (!password.Any(char.IsLower)) { return false; }
            if (!password.Any(c => HasSpecialCharacter(c))) { return false; }
            if (password.Any(char.IsWhiteSpace)) { return false; }

            return true;

        }

        // ıt has @ symbol or not
        public static bool IsThereAt(char c)
        {
            string atc = "@";
            return atc.Contains(c);

        }

        //User's real name validation function
        public static bool UserRealNameValidation(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(name[0]))
                {
                    return false;
                }
            }

            if (name.Any(c => HasSpecialCharacter(c)))
            {
                return false;
            }

            return true;
        }

        //User's e-post validation function
        public static bool UserEpostValidation(string email)
        {
            

            if (!email.Contains("@")) 
            {
                return false;
            }

            if (HasSpecialCharacter(email[0]))
            {
                return false;
            }

            return true;
        }

        //User tel no validation funciton
        public static bool UserTelNoValidation(string telNo)
        {
            // Check phone number length
            if (telNo.Length != 12) // Must be 12 characters in total (xxx-xxx-xxxx)
            {
                return false;
            }

            // Check "-" signs in correct position
            if (telNo[3] != '-' || telNo[7] != '-')
            {
                return false;
            }

            //Check for non-digit characters
            for (int i = 0; i < telNo.Length; i++)
            {
                if (i == 3 || i == 7)
                {
                    continue; // Don't check for "-" signs, continue
                }

                if (!char.IsDigit(telNo[i]))
                {
                    return false; // If there is a character that is not a number, consider it as incorrect.
                }
            }

            // Accept as true if all conditions are passed
            return true;
        }


    }

    public class Admin : User
    {
        public Admin(string username, string password) : base(username, password) { }

        public static void RemoveCustomer(string user_name, List<Customer> Customers) //The process remove customer
        {   //it's find customer for given username
            Customer delete_customer = Customers.FirstOrDefault(x => x.Username == user_name);
            if (delete_customer != null)
            {   //removing customer from list
                Customers.Remove(delete_customer);
                delete_customer = null; //remove from memory
                Console.WriteLine( $"Customer {user_name} was successfully deleted");

            }
            else
            {
                Console.WriteLine("There is no user you want to delete..");
            }

        }

        public static void RemoveDealer(string user_name, List<Dealer> Dealers) //The process remove dealer
        {   //it's find dealer from given username
            Dealer delete_dealer = Dealers.FirstOrDefault(x => x.Username == user_name);
            if (delete_dealer != null) // until null
            {   //remove dealer from list
                Dealers.Remove(delete_dealer);
                delete_dealer = null; //remove memory
                Console.WriteLine($"The seller {user_name} was successfully deleted");

            }
            else
            {
                Console.WriteLine("There is no user you want to delete..");
            }

        }
       
       public static List<Admin> CreateAdmin()
        {
            List<Admin> admins = new List<Admin>(); //create admin object
            Admin admin = new Admin("adminn5", "Admin2024@"); //given info
            admins.Add(admin);// add the admins list

            return admins; 
        }

        public static void RemoveCar(int carId, List<Car> Cars) 
        {   //It finds Car from given CarId
            Car delete_car = Cars.FirstOrDefault(x => x.CarId == carId);
            if (delete_car != null)
            {
                Cars.Remove(delete_car); // Remove Car
                Console.WriteLine($"The car with ID {carId} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine("No car was found for this ID.");
            }
        }

        public static void RemoveTrimPackage(int carId, int packageId, List<Car> Cars)
        {   //It finds car from given carıd
            Car cars = Cars.FirstOrDefault(c => c.CarId == carId);
            if (cars != null)//until null
            {    //It finds trim package from given package ıd
                TrimPackage trimpackages = cars.Packages.FirstOrDefault(x => x.PackageId == packageId);
                if (trimpackages != null) //until null
                {
                    cars.Packages.Remove(trimpackages); //removing package
                    Console.WriteLine($"\nThe car with Car ID :  {carId} and package ID :  {packageId} has been deleted successfully.");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("\nPackage not found !");
                }
            }
            else
            {
                Console.WriteLine("\nCar not found !");
            }
        }

        public static void RemoveSparePart(int carId, int packageId, int partId, List<Car> Cars)
        {   //It finds car from given carıd
            Car car = Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {   //It finds trim package from given package ıd
                TrimPackage package = car.Packages.FirstOrDefault(p => p.PackageId == packageId);
                if (package != null)
                {    //It finds spare part from given part ıd
                    SparePart part = package.SpareParts.FirstOrDefault(s => s.PartId == partId);
                    if (part != null)
                    {
                        // removig spareparts process
                        package.SpareParts.Remove(part);
                        Console.WriteLine($"The car with Car ID {carId} - package ID : {packageId} - part ID : {partId} has been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Part not found in the package.");
                    }
                }
                else
                {
                    Console.WriteLine("Package not found in the car.");
                }
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }


    }

    public class Customer : User
    {   // Private fields for name, email, and phone
        private string name;
        private string eMail;
        private string phone;

        // Public properties for name, email, and phone
        public string Name { get => name; set => name = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string Phone { get => phone; set => phone = value; }
       
        // Property representing the shopping cart of the customer
        public List<SparePartOnCart> ShoppingCart { get; } // This line represents an unmodifiable reference to a list of SparePartOnCart items.

        // Constructor for Customer class initializing its properties including name, email, phone, and ShoppingCart
        public Customer(string name, string username, string password, string eMail, string phone) : base(username, password)
        {
            this.Name = name;// Initializes the Name property
            this.EMail = eMail;// Initializes the EMail property
            this.Phone = phone;// Initializes the Phone property
            this.ShoppingCart = new List<SparePartOnCart>(); // Initializes the ShoppingCart list
        }



        public void AddToCart(SparePart spart)
        {
            ShoppingCart.Add(new SparePartOnCart(spart)); // Adds a new SparePartOnCart item to the ShoppingCart based on the given SparePart
        }

        public void ViewCart()
        {
            // Check if the shopping cart is empty
            if (ShoppingCart.Count == 0)
            {
                Console.WriteLine("Shopping cart is empty");
            }
            else
            {
                // Display the contents of the shopping cart
                Console.WriteLine("Available Cart : ");
                foreach (var p in ShoppingCart)
                {
                    string saleStatus = "Request not answered";

                    // Check if the sale status is available and set the appropriate message
                    if (p.DealerApprove != null)
                    {
                        saleStatus = p.DealerApprove.Value ? "Purchase Positive" : "Purchase Negative";
                    }

                    // Display information about each spare part in the cart including its sale status
                    Console.WriteLine($"Car Id : {p.CarId} - TrimPackageId : {p.PackageId} - SparePartId:{p.PartId}. {p.SparePartName}. \t Sale Status = {saleStatus}\n");
                }
            }
        }

        public static List<Customer> CreateCustomer()
        {
            // Create a new list to store customer objects
            List<Customer> customersList = new List<Customer>();

            // Create Customer objects with predefined data
            Customer c1 = new Customer("Stephen", "stephen", "2023Stph@", "stephen23@gmail.com", "987-435-2345");
            Customer c2 = new Customer("Suzan", "suzan", "57Suzan+", "suzan57@gmail.com", "965-437-1236");

            // Add the created Customer objects to the list
            customersList.Add(c1);
            customersList.Add(c2);

            // Return the list of customers
            return customersList;
        }

        public static void DeleteCustomerAccount(string username, List<Customer> customers)
        {
            // Find the customer in the list based on the provided username
            var customer = customers.FirstOrDefault(c => c.Username == username);

            // If the customer with the specified username is found...
            if (customer != null)
            {
                customers.Remove(customer); // Remove the customer from the list
                Console.WriteLine($"The customer named {username} has been deleted."); // Display a success message
            }
            else
            {
                Console.WriteLine("Account not found..."); // If the customer is not found, display an error message
            }
        }

    }

    public class Dealer : User
    {
        public Dealer(string username, string password) : base(username, password) { }

        public static List<Dealer> CreateDealer()
        {
            // Create a new list to store dealer objects
            List<Dealer> dealersList = new List<Dealer>();

            // Create Dealer objects with predefined data
            Dealer d1 = new Dealer("eymen", "123456Ae-");
            Dealer d2 = new Dealer("zeynep", "57Zeynep@");

            // Add the created Dealer objects to the list
            dealersList.Add(d1);
            dealersList.Add(d2);

            // Return the list of dealers
            return dealersList;
        }

        public static void AddCar(List<Car> cars)
        {
            Console.WriteLine("Enter the details for the new car:");

            // Gather information for the new car
            Console.WriteLine("Brand:");
            string brand = Console.ReadLine();

            Console.WriteLine("Model:");
            string model = Console.ReadLine();

            Console.WriteLine("Year:");
            int year = Convert.ToInt32(Console.ReadLine());

            // Create a new car object with the collected information and add it to the list of cars
            Car newCar = new Car(GenerateCarId(cars), brand, model, year);
            cars.Add(newCar);

            Console.WriteLine("Enter the trim package infos for the new car:");

            bool addPackage, addPart;
            int partId = 1;

            // Add trim packages and their respective spare parts for the new car
            do
            {
                Console.WriteLine("Package Name:");
                string packageName = Console.ReadLine();

                // Create a new trim package for the car and add it to the car's list of packages
                TrimPackage package = new TrimPackage(newCar.CarId, GeneratePackageId(cars), packageName);
                newCar.Packages.Add(package);

                partId = 1;

                // Add spare parts for the current package
                Console.WriteLine("Enter the spare part infos for the new car package:");
                do
                {
                    Console.WriteLine("Part Name:");
                    string partName = Console.ReadLine();

                    Console.WriteLine("Inventory Count:");
                    int count = 0;
                    int.TryParse(Console.ReadLine(), out count);

                    // Create a new spare part for the car's package and add it to the package's list of spare parts
                    SparePart part = new SparePart(newCar.CarId, package.PackageId, partId, partName, count);
                    package.SpareParts.Add(part);
                    partId++;

                    Console.WriteLine("Do you want to add spare part for this car package: Yes(Y) or No(N)");
                    var chose = Console.ReadKey();
                    addPart = chose.Key == ConsoleKey.Y ? true : false;

                } while (addPart);

                Console.WriteLine("Do you want to add package for this car: Yes(Y) or No(N)");
                var choose = Console.ReadKey();
                addPackage = choose.Key == ConsoleKey.Y ? true : false;

            } while (addPackage);

            Console.WriteLine("New car added successfully!");
        }

        // Function to create a new vehicle ID
        static int GenerateCarId(List<Car> cars)
        {
            int max = 0;

            // Loop through the existing cars to find the maximum ID
            foreach (var c in cars)
            {
                max = Math.Max(max, c.CarId);
            }

            return max + 1; // Returns the next ID after the maximum ID present in the list
        }

        // Function to create a new package ID
        static int GeneratePackageId(List<Car> cars)
        {
            int maxPackageId = 0;
            foreach (var car in cars)
            {
                foreach (var p in car.Packages)
                {
                    maxPackageId = Math.Max(maxPackageId, p.PackageId);
                }
            }
            return maxPackageId + 1;
        }

        public static void UpdateSparePartsInventory(List<Car> Cars, int carId, int packageId, int partId)
        {
            
            Car car = Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                // Update car's spare parts
                TrimPackage package = car.Packages.FirstOrDefault(s => s.PackageId == packageId);
                if (package != null)
                {
                    SparePart part = package.SpareParts.FirstOrDefault(p => p.PartId == partId);
                    if (part != null)
                    {
                        Console.WriteLine($"Avaliable count of {part.SparePartName} = {part.InventoryCount}\n");
                        Console.WriteLine("Please enter your new count : ");
                        int newInventoryCount = int.Parse(Console.ReadLine());
                        part.InventoryCount = newInventoryCount;
                        Console.WriteLine($"New count of {part.SparePartName} = {part.InventoryCount}\n");
                    }
                }                
            }
        }

        public static void RemoveCar(int carId, List<Car> Cars)
        {    
            Car delete_car = Cars.FirstOrDefault(x => x.CarId == carId);
            if (delete_car != null)
            {   
                Cars.Remove(delete_car);
                Console.WriteLine($"The car with ID {carId} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine("No car was found for this ID.");
            }
        }

        public static void RemoveTrimPackage(int carId , int packageId, List<Car> Cars)
        {
            Car cars = Cars.FirstOrDefault(c => c.CarId == carId);
            if(cars != null)
            {
                TrimPackage trimpackages = cars.Packages.FirstOrDefault(x=>x.PackageId == packageId);
                if(trimpackages !=null)
                {
                    cars.Packages.Remove(trimpackages);
                    Console.WriteLine($"\nPart with ID {packageId} has been successfully removed.");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("\nPackage not found !");
                }
            }
            else
            {
                Console.WriteLine("\nCar not found !");
            }
        }
      
        public static void RemoveSparePart(int carId, int packageId, int partId, List<Car> Cars, List<Customer> Customers)
        {
            Car car = Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                TrimPackage package = car.Packages.FirstOrDefault(p => p.PackageId == packageId);
                if (package != null)
                {
                    SparePart part = package.SpareParts.FirstOrDefault(s => s.PartId == partId);
                    if (part != null)
                    {
                        // Checking if the part is in any customer's cart
                        foreach (Customer customer in Customers)
                        {
                            if (customer.ShoppingCart.Any(p => p.PartId == partId))
                            {
                                Console.WriteLine("This part is in a customer's shopping cart. Please respond to the purchase request first.");
                                return;
                            }
                        }

                        // The item is not in any customer's cart, deletion must be continued
                        package.SpareParts.Remove(part);
                        Console.WriteLine($"Part with ID {partId} has been successfully removed.");
                    }
                    else
                    {
                        Console.WriteLine("Part not found in the package.");
                    }
                }
                else
                {
                    Console.WriteLine("Package not found in the car.");
                }
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }

        public static void DeleteDealerAccount(string username, List<Dealer> dealers)
        {
                var dealer = dealers.FirstOrDefault(d => d.Username == username);
                if (dealer != null)
                {
                    dealers.Remove(dealer);
                    Console.WriteLine($"The dealer named {username} has been deleted.");
                }
                else
                {
                    Console.WriteLine("Account not found...");
                }
            
        }

    }
}
