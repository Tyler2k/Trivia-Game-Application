// Tyler Pearson CIS 345 Final Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    public class Question
    {

        // Array to hold answers for each question
        protected AnswerChoice[] choices = new AnswerChoice [4];
        protected string text = "";
        protected int intCorrectChoice = 0;
        protected string feedback = "";
        protected string q = "";
        protected string a0 = "";
        protected string a1 = "";
        protected string a2 = "";
        protected string a3 = "";


        // Overloaded question constructor
        public Question(string q, string a0, string a1, string a2, string a3, int intCorrectAnswer, string feedback)
        {
            
            text = q;
            choices[0] = new AnswerChoice(a0);            
            choices[1] = new AnswerChoice(a1);
            choices[2] = new AnswerChoice(a2);
            choices[3] = new AnswerChoice(a3);
            CorrectChoice = intCorrectAnswer;
            Feedback = feedback;
        }

        public AnswerChoice[] Choices
        {
            get { return choices; }
            set { this.choices = value; }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public int CorrectChoice
        {
            get { return this.intCorrectChoice; }
            set { this.intCorrectChoice = value; }
        }

        public string Feedback
        {
            get { return this.feedback; }
            set { this.feedback = value; }
        }

        public string A0
        {
            get { return this.a0; }
            set { this.a0 = value; }
        }

        public string A1
        {
            get { return this.a1; }
            set { this.a1 = value; }
        }

        public string A2
        {
            get { return this.a2; }
            set { this.a2 = value; }
        }

        public string A3
        {
            get { return this.a3; }
            set { this.a3 = value; }
        }

        // User can add a new question to the question bank
        public static Question AddQuestion()
        {
            // How many times the user entered invalid information
            int inputTries = 0;
            int intCorrectAnswer;
            while (true)
            {
                try
                {
                    Console.Clear();
                    TriviaManagement.WriteCenteredLine("Trivia Game - Add Question\n\n");
                    Console.WriteLine("Question Text: This is the default Question String.\n");
                    Console.WriteLine("1.Default Answer Choice 1\n2.Default Answer Choice 2\n3.Default Answer Choice 3\n4.Default Answer Choice 4\n\n");
                    Console.WriteLine("Answer: 0\nFeedback: Default Feedback\n\n");
                    Console.Write("Enter question text: ");
                    string q = Console.ReadLine();
                    Console.Write("Enter Choice 1: ");
                    string a0 = Console.ReadLine();
                    Console.Write("Enter Choice 2: ");
                    string a1 = Console.ReadLine();
                    Console.Write("Enter Choice 3: ");
                    string a2 = Console.ReadLine();
                    Console.Write("Enter Choice 4: ");
                    string a3 = Console.ReadLine();
                    Console.Write("Enter correct answer (1-4): ");
                    bool valid = Int32.TryParse(Console.ReadLine(), out intCorrectAnswer);
                    // Continues looping until the user enters a number 1-4
                    while (true)
                    {                      
                        if(valid == true && intCorrectAnswer == 1 || intCorrectAnswer == 2 || intCorrectAnswer == 3 || intCorrectAnswer == 4)
                        {
                            intCorrectAnswer--;
                            break;                            
                        }
                        else
                            Console.Write("Enter correct answer (1-4): ");
                            intCorrectAnswer = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    Console.Write("Enter feedback: ");
                    string feedback = Console.ReadLine();
                    // Creates a new question with the given information
                    Question tmpQuestion = new Question(q, a0, a1, a2, a3, intCorrectAnswer, feedback);
                    // Increments question count
                    TriviaManagement.questionCount++;
                    return tmpQuestion;                    
                }
                catch (Exception)
                {   // If user fails to enter correct data 3 times, the application exits
                    inputTries++;
                    if (inputTries == 3)
                    {
                        Console.WriteLine("You seem to be having issues.  The application will now exit");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        Environment.Exit(0);                       
                    }
                    // Didn't enter a numeric value or left it blank
                    else
                    {
                        Console.WriteLine("Input must be numeric.  Press any key to try again.");

                        Console.ReadKey(true);
                    }
                }
            }
        }

        // Allows user to edit a question currently in the question bank
        public static void EditQuestion()
        {

            Console.Clear();
            // Keeps track of how many times the user enter invalid information
            int inputTries = 0;
            while (true)
                {
                if (inputTries == 3)
                {
                    Console.WriteLine("You seem to be having issues.  The application will now exit");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
                try
                    {
                    Console.Clear();
                    TriviaManagement.WriteCenteredLine("Trivia Game - Edit Question\n\n");
                    Console.Write("Enter question number you would like to edit (1-{0}): ", TriviaManagement.questionCount);
                    int temp = Convert.ToInt32(Console.ReadLine());
                    int correctChoice;
                    DisplayQuestion(temp - 1);
                    Console.Write("Enter question text: ");
                    TriviaManagement.questionBank[temp-1].text = Console.ReadLine();
                    Console.Write("Enter choice 1: ");
                    TriviaManagement.questionBank[temp-1].Choices[0].AnswerText = Console.ReadLine();
                    Console.Write("Enter choice 2: ");
                    TriviaManagement.questionBank[temp-1].Choices[1].AnswerText = Console.ReadLine();
                    Console.Write("Enter choice 3: ");
                    TriviaManagement.questionBank[temp-1].Choices[2].AnswerText = Console.ReadLine();
                    Console.Write("Enter choice 4: ");
                    TriviaManagement.questionBank[temp-1].Choices[3].AnswerText = Console.ReadLine();
                    Console.Write("Enter correct answer (1-4): ");
                    bool valid = Int32.TryParse(Console.ReadLine(), out correctChoice);
                    // Continues looping until the user enters a number 1-4
                    while (true)
                    {
                        if (valid == true && correctChoice == 1 || correctChoice == 2 || correctChoice == 3 || correctChoice == 4)
                        {
                            correctChoice--;
                            break;
                        }
                        else
                            Console.Write("Enter correct answer (1-4): ");
                            valid = Int32.TryParse(Console.ReadLine(), out correctChoice);
                    }
                    TriviaManagement.questionBank[temp - 1].intCorrectChoice = correctChoice;
                    Console.Write("Enter feedback: ");
                    TriviaManagement.questionBank[temp-1].feedback = Console.ReadLine();
                    Console.Clear();
                    TriviaManagement.WriteCenteredLine("Trivia Time - Question Updated\n\n");
                    DisplayQuestion(temp - 1);
                    Console.WriteLine("Press any key to exit to the main menu...");
                    Console.ReadKey(true);
                    break;
                    }
                    catch (NullReferenceException)
                    {
                        // Number entered was greater than the number of questions
                        inputTries++;
                        Console.WriteLine("Number must be between 1 and {0}\n", TriviaManagement.questionCount);
                        Console.ReadKey(true);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // Number entered was larger than the array
                        inputTries++;
                        Console.WriteLine("\nNumber must be between 1 and {0}\n", TriviaManagement.questionCount);
                        Console.ReadKey(true);
                    }
                    catch (Exception)
                    {
                        // Didn't enter a numeric value or nothing at all
                        inputTries++;
                        Console.WriteLine("\nMust enter a numeric value.\n");
                        Console.ReadKey(true);
                    }
            }
            
        }
        // Displays the question detail
        public static void DisplayQuestion(int questionNumber)
        {
            Console.WriteLine("\nQuestion Text: " + TriviaManagement.questionBank[questionNumber].text + "\n");
            Console.WriteLine("1. " + TriviaManagement.questionBank[questionNumber].Choices[0].AnswerText);
            Console.WriteLine("2. " + TriviaManagement.questionBank[questionNumber].Choices[1].AnswerText);
            Console.WriteLine("3. " + TriviaManagement.questionBank[questionNumber].Choices[2].AnswerText);
            Console.WriteLine("4. " + TriviaManagement.questionBank[questionNumber].Choices[3].AnswerText + "\n\n");
            Console.WriteLine("Answer: " + TriviaManagement.questionBank[questionNumber].CorrectChoice);
            Console.WriteLine("Feedback: " + TriviaManagement.questionBank[questionNumber].Feedback + "\n\n");
        }
        // Over loaded method to display questions for trivia game
        public static void DisplayQuestion(int correct, int questionNumber, int total)
        {
            Console.Clear();
            TriviaManagement.WriteCenteredLine("Trivia Now\n\n\n");
            Console.WriteLine("\nQuestion {0}: " + TriviaManagement.questionBank[questionNumber - 1].text + "\n", total + 1);
            Console.WriteLine("1. " + TriviaManagement.questionBank[questionNumber - 1].Choices[0].AnswerText);
            Console.WriteLine("2. " + TriviaManagement.questionBank[questionNumber - 1].Choices[1].AnswerText);
            Console.WriteLine("3. " + TriviaManagement.questionBank[questionNumber - 1].Choices[2].AnswerText);
            Console.WriteLine("4. " + TriviaManagement.questionBank[questionNumber - 1].Choices[3].AnswerText + "\n\n");
        }

        // Takes user's input and displays all questions containing that string
        public static void SearchQuestions(Question[] questionBank)
        {
            // variable to hold how many questions were found in the search
            int numQuestionsFound = 0;
            Console.Clear();
            TriviaManagement.WriteCenteredLine("Triva Time - Search\n\n\n");
            Console.Write("\nEnter search string: ");
            string temp = Console.ReadLine();
            Console.WriteLine();
            TriviaManagement.WriteCenteredLine("SEARCH RESULTS\n\n");
            // Cycles through the array of questions and compares the user input to each question
            for (int i = 0; i < TriviaManagement.questionCount; i++)
            {
                // If it does find a match, it displays the question
                if(questionBank[i].text.ToLower().Contains(temp.ToLower()) && temp != String.Empty)
                {
                    Console.WriteLine("{0,-10}" + questionBank[i].text, i + 1 + "." );
                    numQuestionsFound++;
                }                
            } 
            // After cycling through the whole array, if the number of questions found is still 0           
            if(numQuestionsFound == 0)
            {
                Console.WriteLine("No questions were found with that search string");
            }
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey(true);
        }

        // Initiates a game of trivia
        public static void PlayTrivia()
        {
            // Variable to hold total number of questions
            int total = 0;
            // Variable to hold how many questions the player has gotten right
            int numberRight = 0;
            // Variable to keep track of how many times the player enters an input per question
            int inputTries = 0;
            // Variable to store the player's answer input
            int temp = -1;
            // Continue the game as long as the player hasn't used all three tries  
            bool returnToMenu = false;          
            while (total < 3)
            {
                Random rnd = new Random();                        
                // Selects a random question to be selected
                int questionNumber = rnd.Next(1, TriviaManagement.questionCount + 1);
                int correct = TriviaManagement.questionBank[questionNumber - 1].CorrectChoice;
                inputTries = 0;                      
                while (inputTries < 3)
                {
                    try
                    {
                        DisplayQuestion(correct, questionNumber, total);
                        Console.Write("Your answer (1-4): ");
                        inputTries++;
                        temp = Convert.ToInt32(Console.ReadLine());
                        break;
                            
                    }
                    catch (Exception)
                    {
                        // After 3 input tries the user is sent back to the main menu
                        if (inputTries == 3)
                        {
                            Console.WriteLine("You seem to be having issues.  The application will now exit");
                            Console.WriteLine("\nPress any key to continue...");
                            returnToMenu = true;
                            Console.ReadKey(true);                            
                        }
                        // Didn't enter a numeric value or left it blank
                        else
                        {
                            Console.WriteLine("Input must be numeric.  Press any key to try again.");
                                
                            Console.ReadKey(true);
                        }
                    }
                }
                    if (returnToMenu == true)
                        break;
                CheckAnswer(ref temp, ref questionNumber, ref numberRight, ref total, ref correct);
                    
            }
           
        }

        // Checks if the answer is correct
        public static void CheckAnswer(ref int temp, ref int questionNumber, ref int numberRight, ref int total, ref int correct)
        {
            // If the player makes the correct choice display score and increment total and numberRight
            if (temp == TriviaManagement.questionBank[questionNumber - 1].CorrectChoice + 1)
            {
                Console.WriteLine("\nCorrect! {0}.", TriviaManagement.questionBank[questionNumber - 1].Feedback);
                numberRight++;
                total++;
                Console.WriteLine("\nYour score is {0}/{1}", numberRight, total);

                // If the player gets all questions right, they win!
                if (total == 3 && numberRight == 3)
                {
                    Console.WriteLine("Congratulations, you win!");
                }
                else if (total == 3 && numberRight != 3)
                {
                    Console.WriteLine("\nGAME OVER");
                    Console.ReadKey(true);
                }
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey(true);
                        

            }
            // The player guessed wrong, display correct choice and only increment total
            else
            {
                total++;
                Console.WriteLine("Incorrect :-( The correct answer is {0}.", TriviaManagement.questionBank[questionNumber - 1].Choices[correct].AnswerText);
                Console.WriteLine("\nYour score is {0}/{1}", numberRight, total);
                Console.WriteLine("\n\nPress any key to continue...");
                // If the player used all three guesses and didn't get them all right, then game over
                if (total == 3 && numberRight != 3)
                {
                    Console.WriteLine("\nGAME OVER");

                    Console.ReadKey(true);
                }
                else
                    Console.ReadKey(true);


            }
        }

    }
}
