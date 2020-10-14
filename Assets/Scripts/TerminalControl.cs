using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    //Chosen level
    int level;
    string password;

    string[] Level1Passwords = { "book", "pencil", "text" };
    string[] Level2Passwords = { "prison", "shocker", "judge" };
    string[] Level3Passwords = { "astronaut", "interstellar", "observatory" };

    const string menuHint = "Type \"menu\" to come back to menu.";
    void Start()
    {
        ShowMainMenu("Maksim");
    }

    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;

        Terminal.ClearScreen();
        Terminal.WriteLine($"Hello, {playerName}!");
        Terminal.WriteLine("Please, choose terminal to hack");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type \"1\" to hack library");
        Terminal.WriteLine("Type \"2\" to hack Police station");
        Terminal.WriteLine("Type \"3\" to hack Spaceship");
        Terminal.WriteLine("Ваш выбор:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("welcome back");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            HackingTerminal(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            Terminal.ClearScreen();
            GameStart();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello Mr Bond!");
        }
        else if (input == "777")
        {
            Terminal.WriteLine("OMG YOU WON A F*CKING JACKPOT MAN!!! $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
    }
    void HackingTerminal(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Oh shit! You need to try again!");
            GameStart();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;

        switch (level)
        {
            case 1:
                Terminal.WriteLine("YES! You hacked library! Damn man!");
                Terminal.WriteLine(
                    @"Book of everyone's secrets is now yours
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\     
 //________.|.________\\    
`----------`-'----------'
                    ");
                break;
            case 2:
                Terminal.WriteLine("YES! You hacked police! Damn man!");
                Terminal.WriteLine(
                     @"Codes for nuclear missiles is yours!
  /\     |\**/|      
 /  \    \ == /
 |  |     |  |
 |  |     |  |
/ == \    \  /
|/**\|     \/
                    ");
                break;
            case 3:
                Terminal.WriteLine("YES! You hacked space station! Damn!");
                Terminal.WriteLine(
                    @"Government prisoner is now yours
    .  .
     \/
    (@@)
 g/\_)(_/\e
g/\(=--=)/\e
    //\\
   _|  |_ 
                    ");
                break;
        }
        Terminal.WriteLine(menuHint);
    }
    void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine(menuHint);
        switch (level)
        {
            case 1:
                password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];
                Terminal.WriteLine("You're in a library.");
                break;
            case 2:
                password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];
                Terminal.WriteLine("You're in a police station.");
                break;
            case 3:
                password = Level3Passwords[Random.Range(0, Level3Passwords.Length)];
                Terminal.WriteLine("You're in a spaceship.");
                break;
        }
        Terminal.WriteLine($"Tip for a password: {password.Anagram()}");
        Terminal.WriteLine("Enter the password:");
    }
}
