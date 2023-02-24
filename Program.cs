//Andrew Hines
//Final Project
//09.23.2022


using System.Data.SQLite;

public class Application {
    public static void Main(string[] args){
    
    const string dbName = "Vehicle.db"; 
        Console.WriteLine("\nAndrew Hines, Final Project\n"); 
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);
    
    if (conn != null) 
    { 
    VehicleDB.CreateTable(conn);

     Inventory soldInventory = new Inventory();
     Bank bank = new Bank(0);
     
     VehicleDB.AddVehicle(conn, new Vehicle(1, "Ford", "Mustang", "Yellow", "2002", 5000, 6950, 0)); 
     VehicleDB.AddVehicle(conn, new Vehicle(2,"Jeep", "Wrangler", "Green", "2007", 8000, 11500, 0)); 
     VehicleDB.AddVehicle(conn, new Vehicle(3,"Jeep", "Wrangler", "Black", "1992", 3000, 5950, 0)); 
     VehicleDB.AddVehicle(conn, new Vehicle(4, "Nissan", "Xterra", "Red", "2008", 3500, 6950, 0));

     Vehicle vehicle = new Vehicle();
     MainMenu mainMenu = new MainMenu();
     Bank bankMenu = new Bank();

    //Navigation / Main Menu
    string mainMenuSelect = "0";
    string vehicleMenuSelect = "0";
    string bankMenuSelect = "0";
    
    while(mainMenuSelect != "3"){
     Console.WriteLine(mainMenu.DisplayMenu());
     Console.WriteLine("");
     mainMenuSelect = Console.ReadLine();
    
        //Vehicle Menu
        if(mainMenuSelect == "1"){
            Console.WriteLine(vehicle.DisplayMenu());
            Console.WriteLine("");
            vehicleMenuSelect = Console.ReadLine();

            while(vehicleMenuSelect != "5"){

            //View Inventory
            while(vehicleMenuSelect == "1"){
                
            PrintInventory(VehicleDB.GetInventory(conn));
            vehicleMenuSelect = "0";
            Console.WriteLine(vehicle.DisplayMenu());
            vehicleMenuSelect = Console.ReadLine();
            }
            //Add Vehicle
            while(vehicleMenuSelect == "2"){

                Console.WriteLine("Enter Vehicle ID:");
                int newID = Convert.ToInt32(Console.ReadLine());
                Convert.ToInt32(newID);
                Console.WriteLine("Enter Vehicle Make:");
                string newMake = Console.ReadLine();

                Console.WriteLine("Enter Vehicle Model:");
                string newModel = Console.ReadLine();

                Console.WriteLine("Enter Vehicle Color:");
                string newColor = Console.ReadLine();

                Console.WriteLine("Enter Vehicle Year:");
                string newYear = Console.ReadLine();

                Console.WriteLine("Enter Vehicle Purchase Price:");
                int newPurchasePrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Vehicle Selling Price:");
                int newSellingPrice = Convert.ToInt32(Console.ReadLine());
    
                VehicleDB.AddVehicle(conn, new Vehicle(newID, newMake, newModel, newColor, newYear, newPurchasePrice, newSellingPrice, 0));
                vehicleMenuSelect = "0";
                Console.WriteLine(vehicle.DisplayMenu());
                vehicleMenuSelect = Console.ReadLine();
            }
            //Sell Vehicle
            while(vehicleMenuSelect == "3"){
                
                    PrintInventory(VehicleDB.GetInventory(conn));
                    
                    Console.WriteLine("Enter ID of Vehicle to Sell:");
                    int selectedVehicleID = Convert.ToInt32(Console.ReadLine());
                    
                    //Having trouble figuring out how to plug in my GetVehicleProfit Method here
                    vehicleMenuSelect = "0";
                    Console.WriteLine(vehicle.DisplayMenu());
                    vehicleMenuSelect = Console.ReadLine();
                    
                }

            while(vehicleMenuSelect == "4"){
                //Update Vehicle
                PrintInventory(VehicleDB.GetInventory(conn));
                
                Console.WriteLine("Enter Vehicle ID to Update:");
                int updateID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Make of Vehicle:");
                string updateMake = Console.ReadLine();

                Console.WriteLine("Enter Model of Vehicle:");
                string updateModel = Console.ReadLine();

                Console.WriteLine("Enter Color of Vehicle:");
                string updateColor = Console.ReadLine();

                Console.WriteLine("Enter Year of Vehicle:");
                string updateYear = Console.ReadLine();

                Console.WriteLine("Enter Vehicle Purchase Price to Update:");
                int updatePurchasePrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Vehicle Selling Price to Update:");
                int updateSellingPrice = Convert.ToInt32(Console.ReadLine());

                Vehicle vehicleToUpdate = new Vehicle(updateID, updateMake, updateModel, updateColor, updateYear, updatePurchasePrice, updateSellingPrice, 0);
                VehicleDB.UpdateVehicle(conn, vehicleToUpdate);

                vehicleMenuSelect = "0";
                Console.WriteLine(vehicle.DisplayMenu());
                vehicleMenuSelect = Console.ReadLine();
            }
            }//End While
        }//End Vehicle Select Menu

        //Bank Menu
        else if(mainMenuSelect == "2"){
            Console.WriteLine(bankMenu.DisplayMenu());
            Console.WriteLine("");
            bankMenuSelect = Console.ReadLine();
            //Total Profit
            while(bankMenuSelect == "1"){
                Console.WriteLine("Total Profit: $" + bank.TotalProfit);
                bankMenuSelect = "0";
                Console.WriteLine(bankMenu.DisplayMenu());
                bankMenuSelect = Console.ReadLine();
            }
            //Individual Profit
            while(bankMenuSelect == "2"){
                
                PrintInventoryWProfit(VehicleDB.GetInventory(conn));

                bankMenuSelect = "0";
                Console.WriteLine(bankMenu.DisplayMenu());
                bankMenuSelect = Console.ReadLine();
                }
            }
        }
    
    }//End Main Menu Select

}
    private static void PrintInventory(List<Vehicle> inventory) 
    { 
        foreach (Vehicle v in inventory) 
        { 
            PrintVehicle(v); 
        } 
    }

    private static void PrintInventoryWProfit(List<Vehicle> inventory) 
    { 
        foreach (Vehicle v in inventory) 
        { 
            PrintVehicleProfit(v); 
        } 
    }

    private static void PrintVehicleProfit(Vehicle v){
       Console.WriteLine("\nID " + v.ID + ": \nMake: "); 
        Console.WriteLine(v.Make + "\nModel: " + v.Model + "\nColor: " 
            + v.Color + "\nYear: " + v.Year + "\nPurchase Price: " + v.PurchasePrice + "\nSelling Price: " + v.SellingPrice + "\nProfit: $" + v.Profit); 
    }
     private static void PrintVehicle(Vehicle v) 
    { 
        Console.WriteLine("\nID " + v.ID + ": \n"); 
        Console.WriteLine(v.Make + "\n" + v.Model + "\n" 
            + v.Color + "\n" + v.Year + "\n" + v.PurchasePrice + "\n" + v.SellingPrice); 
    }  

    private static void GetVehicleProfit(int id, Vehicle v, Bank bank, SQLiteConnection conn){
      id = v.ID;
      v.Profit = v.SellingPrice - v.PurchasePrice;
      bank.TotalProfit += v.Profit;
      VehicleDB.SellVehicle(conn, id);
    }

    private static void GetTotalProfit(List<Vehicle> inventory){
        foreach (Vehicle v in inventory)
        {
            v.Profit += v.Profit;
        }
    }
}



