/******************************************************************* 
 * Name: Andrew Hines  
 * Date: 09.23.2022
 * Assignment: Final Project
 *  
 * Class to handle all interactions with the Vehicle table in the 
 * database, including creating the table if it doesn't exist and all 
 * CRUD (Create, Read Update, Delete) operations on the Address table. 
 * Note that the interactions are all done using standard SQL syntax 
 * that is then executed by the SQLite library. 
 */ 
using System.Data.SQLite; 
 
public class VehicleDB 
{ 
    public static void CreateTable(SQLiteConnection conn) 
    { 
        // SQL statement for creating a new table 
        string sql = 
            "CREATE TABLE IF NOT EXISTS Vehicle (\n" 
            + "   ID integer PRIMARY KEY\n" 
            + "   ,Make varchar(40)\n" 
            + "   ,Model varchar(40)\n" 
            + "   ,Color varchar(40)\n"
            + "   ,Year varchar(40)\n"
            + "   ,PurchasePrice integer\n"
            + "   ,SellingPrice integer\n" 
            + "   ,Profit integer);"; 
 
 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
 
    public static void AddVehicle(SQLiteConnection conn, Vehicle v) 
    { 
        string sql = string.Format( 
            "INSERT INTO Vehicle(Make, Model, Color, Year, PurchasePrice, SellingPrice, Profit) " 
            + "VALUES('{0}','{1}','{2}', '{3}', {4}, {5}, {6})", 
            v.Make, v.Model, v.Color, v.Year, v.PurchasePrice, v.SellingPrice, v.Profit); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
 
    public static void UpdateVehicle(SQLiteConnection conn, Vehicle v) 
    { 
        string sql = string.Format( 
            "UPDATE Vehicle SET Make='{0}', Model='{1}', Color='{2}', Year='{3}', PurchasePrice={4}, SellingPrice={5}, Profit={6} WHERE ID={7}", 
            v.Make, v.Model, v.Color, v.Year, v.PurchasePrice, v.SellingPrice, v.Profit, v.ID); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
 
    public static void SellVehicle(SQLiteConnection conn, int id) 
    { 
        string sql = string.Format("DELETE from Vehicle WHERE ID = {0}", id); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
 
    public static List<Vehicle> GetInventory(SQLiteConnection conn) 
    { 
        List<Vehicle> inventory = new List<Vehicle>(); 
        string sql = "SELECT * FROM Vehicle"; 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
 
        SQLiteDataReader rdr = cmd.ExecuteReader(); 
 
        while (rdr.Read()) 
        { 
            inventory.Add(new Vehicle( 
                rdr.GetInt32(0), 
                rdr.GetString(1), 
                rdr.GetString(2), 
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetInt32(5),
                rdr.GetInt32(6),
                rdr.GetInt32(7)
            )); 
        } 
 
        return inventory; 
    } 
 
    public static Vehicle GetVehicle(SQLiteConnection conn, int id) 
    { 
        string sql = string.Format("SELECT * FROM Vehicle WHERE ID = {0}", id); 
 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
 
        SQLiteDataReader rdr = cmd.ExecuteReader(); 
 
        if (rdr.Read()) 
        { 
           return new Vehicle( 
                rdr.GetInt32(0), 
                rdr.GetString(1), 
                rdr.GetString(2), 
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetInt32(5),
                rdr.GetInt32(6),
                rdr.GetInt32(7) 
            ); 
        } 
        else 
        { 
            return new Vehicle(-1, string.Empty, string.Empty, string.Empty, string.Empty, -1, -1, -1); 
        } 
    } 
}