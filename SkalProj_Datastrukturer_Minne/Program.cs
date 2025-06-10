using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Markup;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //Huvudmetod för att hantera menyn i programmet
        static void Main()
        {
            while (true)
            {
                string message = ("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ReturnCharInput(message);
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        //Metod för att examinera datastrukturen List genom att lägga till och ta bort element i en lista
        static void ExamineList()
        {
            /* FRÅGOR
              När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                    Den underliggande arraysn storlek ökar när man lägger till ett till element i listan och den redan är full.
              Med hur mycket ökar kapaciteten? 
                    Den ökar till dubbel storlek jämfört med den tidigare kapaciteten.
              Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                     För att det skulle bli innefektivt att öka kapaciteten med 1 varje gång ett element läggs till (KOLLA UPP)
              Minskar kapaciteten när element tas bort ur listan? 
                    Nej det gör den inte, kapaciteten förblir samma.
              När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                    När man vill ha kontroll över hur många element som ska kunna lagras i arrayen. (KOLLA UPP)
             */


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            Console.Write("Please enter a word that you either want to add or remove \nfrom a list.");

            string message = "To add a word, type in + before the word." +
                    "\nTo remove a word type in - before the word \nIf you want to get back to the main menu, " +
                    "please press 0\"";

            List<string> theList = new List<string>();
            do //Do-while loop för att fortsätta fråga användaren om input framtill hen väljer att avsluta
            {
                string? input = ReturnStringInput(message);
                char nav = ' ';
                nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the list. Current count: {theList.Count}, Capacity: {theList.Capacity}\n");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} to the list. Current count: {theList.Count}, Capacity: {theList.Capacity}\n");
                        break;
                    case '0':
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("\nYou should use + and - before the word you want to enter/remove");
                        break;
                }
            } while (true);
        }

        //Metod för att examinera datastrukturen Queue genom att skapa en kö
        static void ExamineQueue()
        {

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.Write("The swedish supermarket Ica has now opened and the queue is empty! \n" +
                "Now it´s up to you what should happen:");

            Queue<string> queue = new Queue<string>();

            do
            {
                char nav = ReturnCharInput("\n1) Put a new person in the line \n2) Serve the first person in the line \n3) See the current queue\n0) End this exersice and return to the main menu\n");
                switch (nav)
                {
                    case '1':
                        string instruction = ("Please enter name of the person that should join the line: ");
                        string name = ReturnStringInput(instruction); //gör validering på detta
                        queue.Enqueue(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {queue.Count}"); //todo är detta samma som hur många platser det finns i kö-listan?
                        break;
                    case '2':
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("That is no one to serve, the line is empty!");
                        }
                        else
                        {
                            Console.WriteLine($"{queue.Peek()} is now being served");
                            queue.Dequeue();
                            Console.WriteLine($"People in line: {queue.Count}");
                        }
                        break;
                    case '3':
                        Console.WriteLine("Current queue: ");
                        foreach (var person in queue)
                        {
                            Console.WriteLine(person);
                        }
                        break;
                    case '0':
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input, only 0-3 is allowed");
                        break;
                }
                Console.WriteLine("\nPlease enter a new number (0-3)");
            } while (true);
        }

        //Metod för att examinera datastrukturen Stack genom att skapa en kö
        static void ExamineStack()
        {
            /* Q: Varför är det inte så smart att använda en stack i det här fallet? 
             *      A: För att en stack kör med LIFO (last in first out) medans köer normalt kör FIFO (first in first out).
             *      Nu får den person som ställer sig sist i kön hjälp först medan den som är först i kön får hjälp sist.
             */

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            Console.WriteLine("The swedish supermarket Ica has now opened and the queue is empty! \n" +
               "Now it´s up to you what should happen:");

            string message = (
               "1) Put a new person in the line\n" +
               "2) Serve the first person in the line\n" +
               "3) See the current queue\n" + //ev ta bort denna extrafunktion
               "4) BONUS: Write a word and get it back backwards\n" +
               "0) Return to the main menu\n");

            Stack<string> stringStack = new Stack<string>();

            do
            {
                char nav = ReturnCharInput(message);
                switch (nav)
                {
                    case '1':
                        string instruction = ("Please enter name of the person that should join the line: ");
                        string name = ReturnStringInput(instruction);
                        stringStack.Push(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {stringStack.Count}"); //todo är detta samma som hur många platser det finns i kö-listan?
                        break;
                    case '2': 
                        if (stringStack.Count == 0)
                        {
                            Console.WriteLine("That is no one to serve, the line is empty!");
                        }
                        else
                        {
                            Console.WriteLine($"{stringStack.Peek()} is now being served");
                            stringStack.Pop();
                            Console.WriteLine($"People in line: {stringStack.Count}");
                        }
                        break;
                    case '3':
                        Console.WriteLine("Current queue: ");
                        foreach (var person in stringStack)
                        {
                            Console.WriteLine(person);
                        }
                        break;
                    case '4':
                        string word = ReturnStringInput("Please enter a word that you want to see backwards: ");
                        Stack<char> charStack = new Stack<char>();

                        foreach (char character in word) //Strängen är uppbyggd av chars, vilket gör att man kan loopa igenom den
                        {
                            charStack.Push(character);
                        }

                        while (charStack.Count > 0) //Så länge det finns tecken i stacken så skrivs de ut
                        {
                            Console.Write(charStack.Pop());
                        }
                        break;
                    case '0':
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input, only 0-4 is allowed");
                        break;
                }
                Console.WriteLine("\nPlease enter a new number (0-4)");
            } while (true);
        }

        //Metod för att examinera datastrukturen Stack genom att kontrollera paranteser
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            do
            {
                string input = ReturnStringInput("Please enter a string using paranthesis. To return to the main menu, press 0 ");
                int firstParanthesis = 0;
                int secondParanthesis = 0;

                if (input == "0")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    List<char> charList = new(input);
                    foreach (char c in charList)
                    {
                        if (c == '(')
                            firstParanthesis++;
                        if (c == ')')
                            secondParanthesis++;
                    }

                    if (firstParanthesis == secondParanthesis)
                        Console.WriteLine($"Your text {input} is well formated, you closed all paranthesis");
                    else
                        Console.WriteLine($"Your text {input} is NOT well formated, you did not closed all paranthesis");
                }
            } while (true);
        }


        //Metod för att validera och returnera en sträng från användarens input
        static string ReturnStringInput(string message)
        {
            string input = string.Empty;
            bool validInput = false;
            do
            {
                Console.WriteLine(message); //Dimitris rekommenderade att flytta ned denna. fixa det. 
                input = Console.ReadLine() ?? String.Empty;
                if (!string.IsNullOrEmpty(input))
                {
                    validInput = true;
                }
            } while (!validInput);
            return input;
        }

        //Metod för att validera och returnera en char från användarens input
        static char ReturnCharInput(string message)
        {
            string input = string.Empty;
            bool validChar = false;
            do
            {
                input = ReturnStringInput(message);
                if (input.Length == 1)
                {
                    validChar = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            } while (!validChar);
            return input[0];
        }
    }
}


