using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Markup;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
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

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /* FRÅGOR
              När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                    Den ökar när man lägger till ett till element i listan och den redan är full.
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

            Console.WriteLine("Please enter a word that you either want to add\n" +
                "or remove from a list.To add a word, type in + before the word.\n" +
                "To remove a word type in - before the word\n" +
                "If you want to get back to the main menu, please press 0");

            List<string> theList = new List<string>();
            do
            {
                string? input = Console.ReadLine(); //todo blev inte till upper??
                char nav = input[0]; //få bort varningen
                string value = input.Substring(1);

                switch (nav)
                {
                    case ('+'): //TOdo: enkla eller dubbla fnuttar?
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the list. Current count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case ('-'):
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} to the list. Current count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case ('0'):
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("You should use + and - before the word you want to enter/remove");
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.WriteLine("The swedish supermarket Ica has now opened and the queue is empty! \n" +
                "Now it´s up to you what should happen:\n" +
                "1) Put a new person in the line\n" +
                "2) Serve the first person in the line\n" +
                "3) See the current queue\n" +
                "0) End this exersice and return to the main menu\n");

            Queue<string> queue = new Queue<string>();

            do
            {
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter name of the person that should join the line: ");
                        string name = Console.ReadLine(); //gör validering på detta
                        queue.Enqueue(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {queue.Count}"); //todo är detta samma som hur många platser det finns i kö-listan?
                        break;
                    case "2": //todo skriv validering för om kön är tom
                        Console.WriteLine($"{queue.Peek()} is now being served");
                        queue.Dequeue();
                        Console.WriteLine($"People in line: {queue.Count}");
                        break;
                    case "3":
                        Console.WriteLine("Current queue: ");
                        foreach (var person in queue)
                        {
                            Console.WriteLine(person);
                        }
                        break;
                    case "0":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input, only 0-3 is allowed");
                        break;
                }
                Console.Write("\nPlease enter a new number (0-3): ");
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
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

            Console.WriteLine("The swedish supermarket Ica has now opened and the queue is empty! \n" + //TOdo gör nått åt den färskräckliga mängden dublicerad kod
               "Now it´s up to you what should happen:\n" +
               "1) Put a new person in the line\n" +
               "2) Serve the first person in the line\n" +
               "3) See the current queue\n" +
               "4) BONUS: Write a word and get it back backwards\n" +
               "0) End this exersice and return to the main menu\n");

            Stack<string> stringStack = new Stack<string>();

            do
            {
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter name of the person that should join the line: ");
                        string name = Console.ReadLine(); //gör validering på detta
                        stringStack.Push(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {stringStack.Count}"); //todo är detta samma som hur många platser det finns i kö-listan?
                        break;
                    case "2": //todo skriv validering för om kön är tom
                        Console.WriteLine($"{stringStack.Peek()} is now being served");
                        stringStack.Pop();
                        Console.WriteLine($"People in line: {stringStack.Count}");
                        break;
                    case "3":
                        Console.WriteLine("Current queue: ");
                        foreach (var person in stringStack)
                        {
                            Console.WriteLine(person);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Please enter a word that you want to see backwards: ");
                        string word = Console.ReadLine() ?? string.Empty;
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
                    case "0":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input, only 0-4 is allowed");
                        break;
                }
                Console.Write("\nPlease enter a new number (0-4): ");
            } while (true);
        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

