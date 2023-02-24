//Andrew Hines
//CIS317 Final Project
//09.16.2022

//MainMenu class also inherits method DisplayMenu from Menu interface. Provides empty constructor so MainMenu object can retrieve method.

public class MainMenu : Menu{

    public MainMenu(){}
    public string DisplayMenu(){
        return "Main Menu:\n\n1 - Vehicles\n2 - Bank\n3 - Exit";
    }
}