using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizGame.Bus
{
    public enum QuizOptionType
    {
        TrueOrFalse,
        Numeric,
        Alphabetic
    }

    public struct Quiz
    {
        private QuizOptionType type;
        
        private string question;
        private int answerIndex;

        private string[] choices; 

        public Quiz(QuizOptionType type, string question, string[] choices, int answerIndex)
        {
            this.type = type;
            this.question = question;
            this.choices = choices;
            this.answerIndex = answerIndex;
        }

        public void Answer(ref int counter)
        {
            string input = string.Empty;
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
                input = Console.ReadLine().ToUpper();

                if (input.Length == 1 && IsValidAnswer(input[0]))
                {
                        break;
                }

                Console.WriteLine("\nCette réponse n'est pas valide!\n");
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

        private bool IsValidAnswer(char[] indexCharacters, char inputCharacter)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                if(inputCharacter == indexCharacters[i])
                {
                    return true;
                }

                if (i == indexCharacters.Length - 1)
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
                case QuizOptionType.TrueOrFalse:
                    return new char[] { 'V', 'F' }

                case QuizOptionType.Numeric:
                    return new char[] { '1', '2', '3', '4', '5' };

                case QuizOptionType.Alphabetic:
                    return new char[] { 'A', 'B', 'C', 'D', 'E' };
            }

            return null;
        }

        private void GetState()
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
    }
}
