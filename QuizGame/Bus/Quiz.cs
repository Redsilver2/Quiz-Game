using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizGame.Bus
{
    public enum QuizType
    {
        TrueOrFalse,
        MultipleChoice,
    }

    public struct Quiz
    {
        private QuizType type;
        
        private string question;
        private int answerIndex;

        private string[] choices; 

        public Quiz(QuizType type, string question, string[] choices, int answerIndex)
        {
            this.type = type;
            this.question = question;
            this.choices = choices;
            this.answerIndex = answerIndex;
        }

        public void Answer(ref int counter)
        {
            string input = string.Empty;
            char   inputCharacter;
            char[] indexCharacters = GetIndexCharacters();

            if(answerIndex > choices.Length - 1)
            {
                answerIndex = choices.Length - 1;
            }
            else if(answerIndex < 0)
            {
                answerIndex = 0;
            }

            Console.WriteLine(GetState());

            while (true)
            {
                Console.Write("Entrer une réponse valide: ");
                input = Console.ReadLine();

                if(input.Length != 1)
                {
                    Console.WriteLine("\nCette réponse n'est pas valide!\n");
                }
                else
                {
                    input = input.ToUpper();
                    inputCharacter = input[0];

                    if (IsValidAnswer(indexCharacters, inputCharacter))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nCette réponse n'est pas valide!\n");
                    }
                }
            }

            Console.WriteLine($"\nLa bonne réponse était ({indexCharacters[answerIndex].ToString().ToUpper()})");

            if (inputCharacter == indexCharacters[answerIndex])
            {
                Console.ForegroundColor = ConsoleColor.Green;//change de couleur  
                Console.WriteLine("\n\t\tBonne reponse!");

                counter++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;//change de couleur  
                Console.WriteLine("\n\t\tMauvaise Réponse!");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public string GetState()
        {
            string description = $"{this.question}\n\n";
            char[] indexCharacters = GetIndexCharacters();

            for (int i = 0; i < choices.Length; i++)
            {
                char indexCharacter = indexCharacters[i];
                string choice = choices[i];

                description += $"{indexCharacter}. {choice}\n";

                if(i == indexCharacters.Length - 1)
                {
                    break;
                }
            }

            return description;
        }

        private bool IsValidAnswer(char[] characters , char inputCharacter)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                if(inputCharacter == characters[i])
                {
                    return true;
                }

                if (i == characters.Length - 1)
                {
                    break;
                }
            }

            return false;
        }

        private char[] GetIndexCharacters() 
        {
            switch (type)
            {
                case QuizType.TrueOrFalse:
                    return new char[] { '1', '2' };

                case QuizType.MultipleChoice:
                    return new char[] { 'A', 'B', 'C' };
            }

            return null;
        }
    }
}
