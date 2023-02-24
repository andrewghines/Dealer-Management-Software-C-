/******************************************************************* 
 * Name: Andrew Hines  
 * Date: 09.23.2022
 * Assignment: Final Project
 *  
 * 
 *Class Bank inherits DisplayMenu method from BankMenu interface. Provides a property and constructor to set it. 
 * Also provides an empty constructor so Bank object can use DisplayMenu method.
 * 
 *  
 */ 

 public class Bank : BankMenu {

 public int TotalProfit { get; set;}

 public Bank(){

 }

 public string DisplayMenu(){
  return "Bank Menu:\n\n1 - Display Total Profit\n2 - Display Profit from Inventory\n3 - Back";
 }

  public Bank(int totalProfit){
    TotalProfit = totalProfit;
  }

 }