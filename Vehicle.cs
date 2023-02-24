//Andrew Hines
//CIS317 3.7 - Final Project
//09.16.2022

/*Class Vehicle inherits and overrides method from Interface "Menu." Vehicle provides several properties
and a constructor to set them. ToString overrides Menu and displays vehicle imformation. */

public class Vehicle : Menu {

    public int ID { get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public string Color {get; set;}
    public string Year {get; set;}
    public int PurchasePrice {get; set;}
    public int SellingPrice {get; set;}
    public int Profit {get; set;}

    public Vehicle(int id, string make, string model, string color, string year, int purchasePrice, int sellingPrice, int profit){
            ID = id;
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            PurchasePrice = purchasePrice;
            SellingPrice = sellingPrice;
            Profit = profit;
            profit = SellingPrice - PurchasePrice;
        }

    public Vehicle(){

    }

        public string DisplayMenu()
    {
        return "Vehicle Menu:\n\n1 - View Inventory\n2 - Add Vehicle\n3 - Sell Vehicle\n4 - Update Vehicle\n5 - Back";
    }

    public override string ToString()
    {
        return string.Format("Make: {0}\nModel: {1}\nYear: {2}\nColor: {3}\nPurchase Price: {4}\nSelling Price: {5}",
            Make, Model, Year, Color, PurchasePrice, SellingPrice);
    }

}