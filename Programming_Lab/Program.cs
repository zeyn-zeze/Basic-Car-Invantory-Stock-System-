
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Programming_Lab
{

    internal class Program
    {
        public static List<Car> Cars; //Creates a list containing car objects
        public static List<Admin> Admins; //Creates a list containing admin's objects
        public static List<Dealer> Dealers; //Create a list containing dealer's objects
        public static List<Customer> Customers; // Create a list containing customer's objects

        static void Main(string[] args)
        {
            // Creating inventories for Cars, Admins, Dealers, and Customers
            Cars = Car.CreateCarInventory();
            Admins = Admin.CreateAdmin();
            Dealers = Dealer.CreateDealer();
            Customers = Customer.CreateCustomer();

            // Loop to continuously display the menu until an exit condition is met
            while (true)
            {
                // Displaying the menu screen and getting user input
                int process = ShowMenuScreen();

                // Switching based on the user's input
                switch (process)
                {
                    // If the user selects 1, display AdminStartingScreen()
                    case 1:
                        AdminStartingScreen();
                        break;

                    // If the user selects 2, display CustomerStartingScreen()
                    case 2:
                        CustomerStartingScreen();
                        break;

                    // If the user selects 3, display DealerStartingScreen()
                    case 3:
                        DealerStartingScreen();
                        break;

                    // If the user selects 4, display SignUpScreen()
                    case 4:
                        SignUpScreen();
                        break;

                    // If the user selects 5, prompt to exit or return to the menu
                    case 5:
                        Console.WriteLine("\nThe application will exit. Do you want to log out? Y (Yes), N (No)");
                        var choose = Console.ReadKey().Key;
                        if (choose == ConsoleKey.Y)
                        {
                            Environment.Exit(1); // Exiting the application
                        }
                        else
                        {
                            ShowMenuScreen(); // Returning to the main menu
                        }
                        break;

                    // If the user enters an invalid choice, prompt for a valid selection
                    default:
                        Console.WriteLine("\nYou made the wrong choice. Try again.");
                        ShowMenuScreen(); // Displaying the menu again
                        break;
                }
            }

        }

        // This function displays a menu screen to the user and returns their choice.
        private static int ShowMenuScreen()
        {
            // Prints the menu title and options to the console.
            Console.WriteLine("\n\t************************ CAR SPARE PARTS SALE SYSTEM ******************************\t\n");
            Console.WriteLine(" 1- ADMIN LOG IN \n 2- CUSTOMER LOG IN \n 3- DEALER LOG IN \n 4- SIGN UP \n 5- EXIT");

            // Waits for user input.
            Console.WriteLine("Please enter your choice:");

            // Gets user input.
            var input = Console.ReadKey();

            // Converts the user-entered character to an integer.
            int process = -1;
            int.TryParse(input.KeyChar.ToString(), out process);

            // Returns the user's choice as an integer.
            return process;
        }


       
       

        static bool CostumerUserValidation(string username, string password)
        {
            bool result = false;

            // Check if username or password is not empty
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                // Validate username and password format
                if (User.IsUserNameValid(username) && User.IsPasswordValid(password))
                {
                    // Check if the customer exists with the provided username
                    if (Customers.Any(x => x.Username == username))
                    {
                        // Get the customer with the provided username
                        Customer loginCust = Customers.First(x => x.Username == username);

                        // Validate the password
                        if (loginCust.Password == password)
                        {
                            // Set result to true for successful login
                            result = true;
                            Console.WriteLine("\nLog In is succesfull!\n");
                        }
                        else
                        {
                            // Password mismatch
                            Console.WriteLine("\n Password not found !\n ");
                        }
                    }
                    else
                    {
                        // Customer not found
                        Console.WriteLine("User not found! \n");
                    }
                }
                else
                {
                    // Invalid username or password format
                    Console.WriteLine("Invalid username or password ! \n");
                }
            }
            else
            {
                // Empty username or password
                Console.WriteLine("Log-In is invalid! Please log in again\n");
            }

            return result;
        }

        static bool AdminUserValidation(string username, string password)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                if (User.IsUserNameValid(username) && User.IsPasswordValid(password))
                {
                    if (Admins.Any(x => x.Username == username))
                    {
                        Admin logınadmin = Admins.First(x => x.Username == username);
                        if (logınadmin.Password == password)
                        {
                            result = true;
                            Console.WriteLine("Log In is succesfull\n");

                        }
                        else
                        {
                            Console.WriteLine("Password not found ! \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User not found \n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password ! \n");
                }

            }
            else
            { Console.WriteLine("Log-In is invalid! Please log in again\n"); }

            return result;

        }

        static bool DealerUserValidation(string username, string password)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                if (User.IsUserNameValid(username) && User.IsPasswordValid(password))
                {
                    if (Dealers.Any(x => x.Username == username))
                    {
                        Dealer logındealer = Dealers.First(x => x.Username == username);
                        if (logındealer.Password == password)
                        {
                            result = true;
                            Console.WriteLine("Log In is succesfull\n");

                        }
                        else
                        {
                            Console.WriteLine("Password not found !\n ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User not found\n ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password !\n ");
                }

            }
            else
            { Console.WriteLine("Log-In is invalid! Please log in again\n"); }

            return result;

        }

        //Admin Login Screen
        static void AdminStartingScreen()
        {
            string admin_name;
            string admin_password;
            Console.Clear();

            Console.WriteLine("Username :");
            admin_name = Console.ReadLine();
            Console.WriteLine("Password:");
            admin_password = Console.ReadLine();


            bool isValid = AdminUserValidation(admin_name, admin_password);
            if (isValid) { AdminScreen(); }
            else
            {
                Console.WriteLine("User Validation Error!\n");
            }
        }

        //Admin Main Screen
        static void AdminScreen()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nWelcome to Admin Panel!!!!");
            Console.WriteLine("1.Remove Costumer");
            Console.WriteLine("2.Remove Dealer");
            Console.WriteLine("3.Remove Car");
            Console.WriteLine("4.Remove Car's Trim Package");
            Console.WriteLine("5.Remove Car's Spare Part");
            Console.WriteLine("6.LOG-OUT");

            Console.WriteLine("Please select an option:");
            string userInput = Console.ReadLine();
            Car car;
            TrimPackage package;
            int car_Id, package_Id, part_Id;
            Console.Clear();

            switch (userInput)
            {
                case "1": //Registered Customer can be deleted...

                    foreach (var customer in Customers)
                    {
                        Console.WriteLine($"{customer.Username}\n");  // all customers are displayed
                    }

                    string delete_name;
                    Console.WriteLine("Which user(customer) do you want to delete?(Please enter username)\n");
                    delete_name = Console.ReadLine(); //The username of the customer to be deleted is obtained

                    foreach (var customer in Customers)
                    {
                        if (customer.Username == delete_name)
                        {
                            Admin.RemoveCustomer(delete_name, Customers);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You entered the wrong username");
                        }

                    }


                    AdminScreen();

                    break;

                case "2": //Registered Seller can be deleted....

                    foreach (var dealer in Dealers)
                    {
                        Console.WriteLine($"{dealer.Username}\n");
                    }

                    string delete_dealer_name;
                    Console.WriteLine("Which user (dealer) do you want to delete?(Please enter username)\n");
                    delete_dealer_name = Console.ReadLine();

                    foreach (var dealer in Dealers)
                    {
                        if (dealer.Username == delete_dealer_name)
                        {
                            Admin.RemoveDealer(delete_dealer_name, Dealers);
                            break;
                        }
                        else
                        {
                            continue;
                        }


                    }

                    AdminScreen();

                    break;

                case "3": //Registered cars and their features can be deleted.

                    foreach (var c in Cars)
                    {
                        Console.WriteLine($"{c.CarId} - {c.Brand}- {c.Model}- {c.Year}");
                    }

                    int delete_car_id;
                    Console.WriteLine("Which car do you want to delete?");
                    delete_car_id = Convert.ToInt16(Console.ReadLine());

                    foreach (var c in Cars)
                    {
                        if (c.CarId == delete_car_id)
                        {
                            Admin.RemoveCar(delete_car_id, Cars);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    AdminScreen();

                    break;

                case "4":// Removing a car's trim package
                    car = Car.List_Cars(Cars);
                    Car.List_Packages(car);
                    Console.WriteLine("\nEnter the ID info of the car you want to delete:");
                    Console.WriteLine("CarId : ");
                    car_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PackageId : ");
                    package_Id = int.Parse(Console.ReadLine());
                    Admin.RemoveTrimPackage(car_Id, package_Id, Cars);
                    AdminScreen();

                    break;

                case "5": //Removing car's spare part
                    car = Car.List_Cars(Cars);
                    package = Car.List_Packages(car);
                    Car.ListSpareParts(car, package);
                    Console.WriteLine("\nEnter the ID ınfo of the car you want to delete:");
                    Console.WriteLine("CarId : ");
                    car_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PackageId : ");
                    package_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PartId : ");
                    part_Id = int.Parse(Console.ReadLine());
                    Admin.RemoveSparePart(car_Id, package_Id, part_Id, Cars);
                    AdminScreen();
                    break;

                case "6": //Logging out

                    ShowMenuScreen();
                    break;

                default: //Message for wrong enter
                    Console.WriteLine("Invalid option!");
                    AdminScreen();
                    break;
            }

        }




        //Customer Login Screen
        static void CustomerStartingScreen()
        {
            Console.Clear();
            string cst_name;
            string cst_password;
            Console.WriteLine("Username : ");
            cst_name = Console.ReadLine();
            Console.WriteLine("Password :");
            cst_password = Console.ReadLine();

            bool isValid = CostumerUserValidation(cst_name, cst_password);
            if (isValid) { CustomerScreen(cst_name); }
            else
            { Console.WriteLine("User Validation Error!\n"); }
        }

        static void CustomerScreen(string user_name)
        {
            Console.ReadKey();
            Console.Clear();
            Customer customer = Customers.FirstOrDefault(c => c.Username == user_name);
            Console.WriteLine("Welcome to the Customer Panel!");
            Console.WriteLine("1. View Available Car Parts");
            Console.WriteLine("2. Add Item to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Delete Account");
            Console.WriteLine("5. Logout");

            Console.WriteLine("Please select an option:");
            string userInput = Console.ReadLine();
            Car car;
            TrimPackage package;
            SparePart part;

            switch (userInput)
            {
                case "1":
                    //Display car and features
                    car = Car.List_Cars(Cars);
                    package = Car.List_Packages(car);
                    Car.ListSpareParts(car, package);

                    while (true)
                    {
                        Console.WriteLine("\nDo you want to continue yes(Y) or no(N):");
                        var choose = Console.ReadKey();
                        Console.WriteLine(" ");
                        if (choose.Key == ConsoleKey.Y)
                        {
                            //  re - rotate car lists if selection is yes
                            car = Car.List_Cars(Cars);
                            package = Car.List_Packages(car);
                            Car.ListSpareParts(car, package);
                        }
                        else if (choose.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("Exiting..\n");
                            break;
                        }
                    }

                    //When the process is completed, you will return to the main screen.
                    CustomerScreen(user_name);

                    break;

                case "2":
                    //Car and package listings are listed
                    car = Car.List_Cars(Cars);
                    package = Car.List_Packages(car);
                    do
                    {
                        Car.ListSpareParts(car, package); //Spare parts of the car are listed

                        Console.WriteLine("Which part do you want to add to cart?");
                        int selected = Convert.ToInt16(Console.ReadLine());

                        part = package.SpareParts.FirstOrDefault(p => p.PartId == selected); //The selected ID is identified with the existing spare part ID.
                        customer.AddToCart(part); //The spare part for the selected ID is added to the cart.


                        Console.WriteLine("Do you want to add another part to Cart? yes(Y) or no(N):");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Y);
                    Console.Clear();
                    CustomerScreen(user_name);

                    break;

                case "3":

                    Console.Clear();
                    // The user's cart and request transactions are displayed
                    customer.ViewCart();

                    CustomerScreen(user_name);
                    break;

                case "4":

                    Customer.DeleteCustomerAccount(user_name, Customers);  // Delete customer account              
                    ShowMenuScreen();

                    break;

                case "5":
                    //Logging out
                    Console.Clear();
                    ShowMenuScreen();
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    // Warn the user when an invalid option is entered
                    CustomerScreen(user_name);
                    break;
            }
        }



        //Dealer Login Screen
        static void DealerStartingScreen()
        {
            Console.Clear();
            string dealer_name;
            string dealer_password;
            Console.WriteLine("Username : ");
            dealer_name = Console.ReadLine();
            Console.WriteLine("Password :");
            dealer_password = Console.ReadLine();

            bool isValid = DealerUserValidation(dealer_name, dealer_password);
            if (isValid) { DealerScreen(dealer_name); }
            else
            { Console.WriteLine("User Validation Error!\n"); }
        }


        static void DealerScreen(string username)
        {
            Console.ReadKey();
            Console.Clear();
            Dealer dealer = Dealers.FirstOrDefault(d => d.Username == username);
            Console.WriteLine("Welcome to Dealer Screen!");
            Console.WriteLine("1.Add Car");
            Console.WriteLine("2.SparePart inventory Update");
            Console.WriteLine("3.Remove Car");
            Console.WriteLine("4.List Customer Carts");
            Console.WriteLine("5.Delete Account");
            Console.WriteLine("6.Remove Car's Spare Part");
            Console.WriteLine("7.Remove Car's Trim Package");
            Console.WriteLine("8.Log-Out");


            Console.WriteLine("Please select an option:");
            string userInput = Console.ReadLine();
            Car car;
            TrimPackage package;
            int car_Id, package_Id, part_Id;

            switch (userInput)
            {
                case "1": //Add a car

                    Dealer.AddCar(Cars);
                    DealerScreen(username);
                    break;

                case "2": //Update car spare parts inventory

                    car = Car.List_Cars(Cars);// Display car and features
                    package = Car.List_Packages(car);
                    Car.ListSpareParts(car, package);

                    // The car , trim package and spare parts of the inventory to be updated are selected
                    Console.WriteLine("\nCar Id = ");
                    int carId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Package Id :");
                    int packageId = int.Parse(Console.ReadLine());
                    Console.WriteLine("SparePart Id =\n ");
                    int partId = int.Parse(Console.ReadLine());
                    Dealer.UpdateSparePartsInventory(Cars, carId, packageId, partId);
                    DealerScreen(username);

                    break;

                case "3":
                    // Cars are listed
                    Car.List_Cars(Cars);
                    Console.WriteLine("\nEnter the ID of the car you want to delete:");
                    Console.WriteLine("CarId :");
                    car_Id = int.Parse(Console.ReadLine());
                    Dealer.RemoveCar(car_Id, Cars);
                    DealerScreen(username);

                    break;

                case "4":

                    Customer cus = SelectCustomer(); //The customer whose cart will be displayed is selected

                    while (true)
                    {   
                        cus.ViewCart(); // The customer's cart is displayed.
                        if (cus.ShoppingCart.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Select the order number you want to process, press Esc to return to the main menu.:");
                            var key = Console.ReadKey();
                            Console.WriteLine(" ");
                            if (key.Key == ConsoleKey.Escape) // If the escape key is pressed, exit is made.
                            {
                                Console.Clear(); //console is cleared
                                break;
                            }
                            else
                            {
                                int.TryParse(key.KeyChar.ToString(), out int choose); //The ID to be processed is selected
                                var selectedPart = cus.ShoppingCart.FirstOrDefault(s => s.PartId == choose); // The entered Id is matched with the ID in the cart
                                while (true)
                                {
                                    Console.WriteLine("To confirm the order: Approve (A), Reject (R)"); // Provides Approval or Rejection action
                                    key = Console.ReadKey();
                                    Console.WriteLine(" ");
                                    if (key.Key == ConsoleKey.A) // if they choose Approving
                                    {
                                        selectedPart.DealerApprove = true; //The seller approves the request
                                        var inventory = Cars.Find(c => c.CarId == selectedPart.CarId) //The selected spare part has a car ID
                                            .Packages.Find(p => p.PackageId == selectedPart.PackageId) //The selected trim package has a package ID
                                                .SpareParts.Find(s => s.PartId == selectedPart.PartId); //The ID of the part selected from the SparePart class is found
                                        inventory.InventoryCount--; // Since the sale is confirmed, 1 is deducted from the stock
                                        break;
                                    }
                                    else if (key.Key == ConsoleKey.R) // if they reject
                                    {
                                        selectedPart.DealerApprove = false; // The seller reject the request
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You made the wrong choice, try again..\n"); // Other choises warning
                                    }
                                }
                            }
                        }
                    }

                    DealerScreen(username);
                    break;

                case "5":

                    //Seller will delete his own account
                    Dealer.DeleteDealerAccount(username, Dealers);
                    Console.Clear();
                    DealerScreen(username);
                    break;

                case "6":
                    // Car and Trim packages and Spare parts listed
                    car = Car.List_Cars(Cars);
                    package = Car.List_Packages(car);
                    Car.ListSpareParts(car, package);
                    //The car ,package,part features to be deleted are entered.
                    Console.WriteLine("\nEnter the ID ınfo of the car you want to delete:");
                    Console.WriteLine("CarId : ");
                    car_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PackageId : ");
                    package_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PartId : ");
                    part_Id = int.Parse(Console.ReadLine());
                    Dealer.RemoveSparePart(car_Id, package_Id, part_Id, Cars, Customers);
                    DealerScreen(username);

                    break;

                case "7":
                    // Car and Trim Packages listed
                    car = Car.List_Cars(Cars);
                    Car.List_Packages(car);
                    //The car and package features to be deleted are entered.
                    Console.WriteLine("\nEnter the ID info of the car you want to delete:");
                    Console.WriteLine("CarId : ");
                    car_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("PackageId : ");
                    package_Id = int.Parse(Console.ReadLine());
                    Dealer.RemoveTrimPackage(car_Id, package_Id, Cars);
                    DealerScreen(username);

                    break;

                case "8":
                    //Logging out
                    Console.Clear();
                    ShowMenuScreen();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    // Warn the user when an invalid option is entered
                    DealerScreen(username);
                    break;

            }
        }


        static Customer SelectCustomer()
        {
            foreach (Customer c in Customers)
            {

                Console.WriteLine($"{c.Username} - {c.Name} - {c.EMail} - {c.Phone}");
            }
            Customer cus;
            Console.WriteLine("Which customer do you want to view cart? Write username please");
            while (true)
            {
                string selected = Console.ReadLine();
                cus = Customers.Find(x => x.Username == selected);
                if (cus == null)
                {
                    Console.WriteLine("Incorrect username entered. Please try again.\n");
                }
                else
                    break;
            }
            return cus;
        }


        //Registration Screen
        static void SignUpScreen()
        {
            Console.Clear();
            string Name;
            string new_password;
            string new_UserName;
            string eMail;
            string phoneNumber;

            Console.WriteLine("Please enter your Name :");
            Name = Console.ReadLine();

            Console.WriteLine("Please enter your Password :");
            new_password = Console.ReadLine();

            Console.WriteLine("Please enter your Username :");
            new_UserName = Console.ReadLine();

            Console.WriteLine("Please enter your E-MAIL :");
            eMail = Console.ReadLine();

            Console.WriteLine("Please enter your TEL-NO:");
            phoneNumber = Console.ReadLine();

            bool isValid = UserSignUpValidation(Name, new_password, new_UserName, eMail, phoneNumber);
            if (isValid) { Console.WriteLine("\nNew Costumer was add succesfuly....\n"); }
            else
            { Console.WriteLine("User Validation Error!\n"); }

        }


        //Checking whether the username is unique or not
        static bool IsUserNameUnique(string user_name)
        {
            // Checks if the username doesn't exist in Admins, Dealers, and Customers lists
            bool isUnique = !Admins.Any(admin => admin.Username == user_name) &&
                            !Dealers.Any(dealer => dealer.Username == user_name) &&
                            !Customers.Any(customer => customer.Username == user_name);

            return isUnique;
        }




        // Additionally, a verification must be created when registering
        static bool UserSignUpValidation(string new_cst_name, string new_cst_password, string new_userName, string eMail, string phoneNumber)
        {
            bool result = false;

            // Checks if any of the input fields are empty
            if (!string.IsNullOrEmpty(new_cst_name) || !string.IsNullOrEmpty(new_cst_password) || !string.IsNullOrEmpty(new_userName) || !string.IsNullOrEmpty(eMail) || !string.IsNullOrEmpty(phoneNumber))
            {
                // Validates each input field using specific validation methods
                if (User.IsUserNameValid(new_userName) && 
                    User.IsPasswordValid(new_cst_password) && 
                    User.UserRealNameValidation(new_cst_name) &&
                    User.UserEpostValidation(eMail) && 
                    User.UserTelNoValidation(phoneNumber))
                {
                    // Checks if the username is unique
                    bool UniqueUserName = IsUserNameUnique(new_userName);
                    if (UniqueUserName)
                    {
                        // Creates a new Customer and adds it to the Customers list
                        Customer new_Customer = new Customer(new_cst_name, new_cst_password, new_userName, eMail, phoneNumber);
                        Customers.Add(new_Customer);
                        return true; // Sign-up successful
                    }
                    else
                    {
                        Console.WriteLine("\nThis username was avaliable!\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nIncorrect entry made!\n");
                }
            }
            else
            {
                Console.WriteLine("\nPlease Fill All Gaps!!\n");
            }

            return result; // Sign-up unsuccessful
        }
    }
}

