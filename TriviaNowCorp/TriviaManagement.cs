// Tyler Pearson CIS 345 Final Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp 
{
    class TriviaManagement 
    {
        // Keeps track of how many questions are in the data file
        public static int questionCount = 0;
        public static QuestionWriter quest = new QuestionWriter();
        // Array of empty question objects ready to store questions
        public static Question[] questionBank = new Question[20];
        static void Main(string[] args)        
        {
            // Displays menu for user to select from
            quest.LoadQuestions(questionBank, ref questionCount);
            DisplayMenu();                   
            Console.ReadLine();      
        }

        public static void DisplayMenu()
        {
            // Does the menu need to be displayed again
            bool resetMenu = true;           
            do
            {
                try
                {
                    ShowMenu();                  
                    // Convert user input to an integer
                    int answer = Convert.ToInt32(Console.ReadLine());


                    switch (answer)
                    {
                        case 1:
                            Console.Clear();
                            WriteCenteredLine("Trivia Game - Question Bank\n\n");
                            // Display questions to user
                            for (int i = 0; i < questionCount; i++)
                            {
                                Console.WriteLine("{0}: " + questionBank[i].Text, i + 1);
                            }
                            Console.Write("\n\nDo you want to see details of a Question?\nPress 'Y' for yes or any other key to exit:");                           
                            string selection = Console.ReadLine().ToLower();
                            // User selects "y" to see the detail of the question
                            if (selection == "y")
                            {
                                Console.Write("Select a question: ");
                                int temp = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                WriteCenteredLine("Trivia Game - Question Detail\n\n");
                                Question.DisplayQuestion(temp - 1);
                                Console.WriteLine("Press any key to return to the main menu...");
                                Console.ReadKey(true);
                                resetMenu = true;
                            }
                            break;
                        case 2:
                            Question.SearchQuestions(questionBank); // Searches user input against question bank
                            break;
                        case 3:
                            // Add user generated question to the question bank
                            questionBank[questionCount] = Question.AddQuestion();                     
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                            break;
                        case 4:
                            Question.EditQuestion(); // Edit question 
                            WriteCenteredLine("Trivia Time - Question Updated");

                            break;
                        case 5:                           
                            quest.SavetoDataFile(); // Save to file
                            break;
                        case 6:                            
                            Question.PlayTrivia(); // Initiate trivia game
                            break;
                        case 7:
                            Environment.Exit(0); // Exit application
                            break;
                        default:
                            Console.WriteLine("Selection must be between 1 and 7.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                            break;
                    }
                }
                catch (Exception)
                {
                    // Didn't enter a numeric value
                    Console.WriteLine("Must enter a numeric value.");
                    Console.ReadKey(true);

                }
            } while (resetMenu == true);
        }

       

        // Centers input string
        public static void WriteCenteredLine(string input)
        {
            int x = (Console.WindowWidth + input.Length) / 2;
            string y = "{0," + x.ToString() + "}";
            Console.WriteLine(y, input);
        }
        
        // List menu options
        public static void ShowMenu()
        {
            
            Console.Clear();
            WriteCenteredLine("Trivia Time\n\n");
            Console.WriteLine("1. List All Questions");
            Console.WriteLine("2. Find Question");
            Console.WriteLine("3. Add Question");
            Console.WriteLine("4. Edit Question");
            Console.WriteLine("5. Save To Data File");
            Console.WriteLine("6. Play Trivia");
            Console.WriteLine("7. Exit");
            Console.Write("\n\nSelect Menu Option: ");
        }



    }
}
