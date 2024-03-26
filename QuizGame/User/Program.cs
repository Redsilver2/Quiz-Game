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
            Author[] authors = new Author[1]{
                new Author("Marvin", new Quiz[]{ new Quiz(QuizOptionType.Numeric, "Are shrimps faster than dolphins?"
                                , new string[] {"True", "False" }, 1),

                        new Quiz(QuizType.Alphabetic, "Which character is more famous?"
                                , new string[] {"Sonic", "Mario", "Doom Slayer" }, 1) })
            }

            while (!isExiting)
            {
                Console.WriteLine("Commande: [Choix] [Index Du Quiz]\n\n" +
                                  "0. Quittez l'application");

                for (int i = 0; i < authorsNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. Quiz de {authors[i].GetName()}");
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

                            if (index < 0 || index >= authors.Length)
                            {
                                Console.WriteLine("\nIl y a une erreur! Il n'y a pas d'autheurs. \n");
                                break;
                            }

                            int arg2 = int.Parse(inputArgs[1]);

                            Author author = authors[index - 1]
                            Quiz[] quizzes = author.GetQuiz();

                            if (quizzes.Length == 0)
                            {
                                Console.WriteLine("\nCe quiz n'existe pas pour cet autheur.\n");
                                break;
                            }

                            int counter = 0;

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
    }
}