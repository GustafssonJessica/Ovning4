using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Windows.Markup;

namespace SkalProj_Datastrukturer_Minne
{

    /* FRÅGOR (Teori och fakta)
     1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion 

            Stacken staplar allt som den ska lagra, som en prydlig stapel är en box med ett visst innehåll ligger över den andra och så fortsätter det.
            Där lagras värdetyper, ex int, double, enum, struct osv. De lagras i sin variabel, i ex "int age = 3" så lagras värdet 3 i age.
            Stacken är självunderhållande och behöver ej bry sig om garbage collection.

            Heapen lagrar inte lika tydligt utan sakerna ligger i vad som utifrån kan ses som en oordning, det som skapats innan ligger inte nödvändigtvis 
            under det som skapas efter. Men det är alltid lätt att komma åt ändå, bara man vet var det ligger (har en referens till det). På heapen 
            lagras referenstyper så som klasser och string.
            Här kan garbage collection komma och städa, om exempelvis det ligger ett objekt där som det inte finns någon referens till.

 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
            Värdetyper är exempelvis int, double, enum, struct med flera, de lagras i stacken.
            Referenstyper är exempelvis klasser, interface och objekt. De lagras i heapen. De lagras ej i sin variabel så som värdetyper gör, 
            utan variabeln har bara en referens till objektet där det finns i heapen.


3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför? 
            I den första används enbart värdetyper, där värdet lagras direkt i variabeln. 
            Y tilldelas samma värde som V har. Förändrar man sedan värdet i Y så påverkas inte värdet som finns lagrat i X, de är frånskilda. 

            I det andra exemplet är int:en en medlemsvariabel i klassen MyInt. Det skapas en instans av MyInt där MyValue tilldelas siffran 3. 
            Referensen till instansen av MyInt är variabeln x. När man sedan tilldelar variabeln y samma referens som variabeln x, så pekar de mot samma objekt. När man genom variabeln y ändrar innehållet i det objektet, så kan man se ändringen även när man går via referensen i variabel x. 
     */



    class Program
    {
        //Huvudmetod för att hantera menyn i programmet
        static void Main() //TOdo förbättra min engelska
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
            /* FRÅGOR LIST
              När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                    Den underliggande arrayen storlek ökar när man lägger till ett till element i listan och den redan är full.
              Med hur mycket ökar kapaciteten? 
                    Den ökar till dubbel storlek jämfört med den tidigare kapaciteten.
              Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                     För att det skulle bli innefektivt att öka kapaciteten med ett i taget. För varje gång som kapaciteten ökar
                     så skapas en ny array med den nya kapaciteten och alla element kopieras över till den nya arrayen.
              Minskar kapaciteten när element tas bort ur listan? 
                    Nej det gör den inte, kapaciteten förblir densamma.
              När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                    När man vill ha kontroll över hur många element som ska kunna lagras i arrayen. Och om det är kritiskt
                    med minnesanvändning, eftersom en lista kan reservera extra minne när den växer.
             */

            Console.Write("Please enter a word that you would like to add or remove from the list.");

            string message = "To add a word, type + before the word.\n" +
                 "To remove a word, type - before the word.\n" +
                 "If you want to return to the main menu, please press 0.";

            List<string> theList = new List<string>();
            do //Do-while loop för att fortsätta fråga användaren om input framtill hen väljer att avsluta genom att trycka 0
            {
                string? input = ReturnStringInput(message);
                char nav = input[0];
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
                        Console.WriteLine("\nYou should use + and - before the word you want to add/remove");
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

            Console.Write("The Swedish supermarket ICA has now opened, and the queue is empty!\n" +
                        "Now it's up to you to decide what happens next:");

            Queue<string> queue = new Queue<string>();

            do
            {
                char nav = ReturnCharInput("\n1) Add a new person to the queue\n2) Serve the first person in the queue\n" +
                    "3) View the current queue\n0) End this exercise and return to the main menu\n");
                switch (nav)
                {
                    case '1':
                        string instruction = ("Please enter name of the person who should join the queue: ");
                        string name = ReturnStringInput(instruction); //gör validering på detta
                        queue.Enqueue(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {queue.Count}"); //todo är detta samma som hur många platser det finns i kö-listan?
                        break;
                    case '2':
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("There is no one to serve, the queue is empty!");
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


            Console.Write("The Swedish supermarket ICA has now opened, and the queue is empty!\n" +
                        "Now it's up to you to decide what happens next:");

            string message = ("\n1) Add a new person to the queue\n2) Serve the first person in the queue\n" +
                    "3) View the current queue\n4) BONUS: Enter a word to see it reversed!\n0) End this exercise and return to the main menu\n");

            Stack<string> stringStack = new Stack<string>();

            do
            {
                char nav = ReturnCharInput(message);
                switch (nav)
                {
                    case '1':
                        string instruction = ("Please enter the name of the person that should join the queue: ");
                        string name = ReturnStringInput(instruction);
                        stringStack.Push(name);
                        Console.WriteLine($"{name} has joined the queue. People in line: {stringStack.Count}");
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
                        string word = ReturnStringInput("Please enter a word to see it reversed: ");
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
            do
            {
                string input = ReturnStringInput("Please enter a string that contains parentheses.To return to the main menu, press 0. ");
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
                        Console.WriteLine($"Your text {input} is well-formatted, you closed all parantheses");
                    else
                        Console.WriteLine($"Your text {input} is NOT well formatted, you did not closed all parantheses");
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


