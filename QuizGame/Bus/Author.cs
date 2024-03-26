using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Bus
{
    internal struct Author
    {
        private string name;
        private Quiz [] quizzes;

        public Author(string name, Quiz[] quizzes)
        {
            this.name = name;
            this.quizzes = quizzes;
        }

        public string GetName() => this.name;
        public Quiz[] GetQuiz() => this.quizzes;
    }
}