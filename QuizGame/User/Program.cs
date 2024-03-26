using QuizGame.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExiting = false;
            string[] authorsNames = new string[] { "Marvin" };

            while (!isExiting)
            {
                Console.WriteLine("Commande: [Choix] [Index Du Quiz]\n\n" +
                                  "0. Quittez l'application");

                for (int i = 0; i < authorsNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. Quiz de {authorsNames[i]}");
                }

                Console.Write("\nEntrez un choix: ");

                string[] inputArgs = Console.ReadLine().Split(new char[] { ' ' });

                try
                {
                    int index = int.Parse(inputArgs[0]);

                    switch (index)
                    {
                        case 0:
                            isExiting = true;
                            break;

                        default:
                            int arg2 = int.Parse(inputArgs[1]);
                            int counter = 0;

                            if (arg2 < 0 || arg2 >= authorsNames.Length)
                            {
                                Console.WriteLine("\nIl y a une erreur! \n");
                                break;
                            }

                            string authorName = authorsNames[index - 1];
                            Quiz[] quizzes = GetQuizByAuthor(authorName, arg2);

                            if (quizzes.Length == 0)
                            {
                                Console.WriteLine("\nIl n'y a pas de quiz pour cet autheur.\n");
                                break;
                            }

                            Console.WriteLine();

                            foreach (Quiz quiz in quizzes)
                            {
                                quiz.Answer(ref counter);
                                Console.WriteLine();
                            }


                            double result = (counter / (double)quizzes.Length) * 100;
                            result = Math.Round(result, 2);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Vous avez eu {counter} bonnes réponses sur {quizzes.Length} \nNote Finale: ({result}%) \n");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nIl y a une erreur! \n");
                }
            }

            Console.WriteLine("Application créé par ...");
            Console.ReadKey();
        }

        private static Quiz[] GetQuizByAuthor(string authorName, int index)
        {
            authorName = authorName.ToLower() + $"{index}";

            switch (authorName)
            {
                case "marvin0":
                    return new Quiz[2]
                    {
                        new Quiz(QuizType.TrueOrFalse, "Are shrimps faster than dolphins?"
                                , new string[] {"True", "False" }, 1),

                        new Quiz(QuizType.MultipleChoice, "Which character is more famous?"
                                , new string[] {"Sonic", "Mario", "Doom Slayer" }, 1)
                    };

                default:
                    return new Quiz[0];
            }
        }
    }
}