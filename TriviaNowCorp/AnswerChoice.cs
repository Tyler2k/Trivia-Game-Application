// Tyler Pearson CIS 345 Final Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    public class AnswerChoice
    {
        // Holds answer text
        protected string answerText = "";

        // Answer choice constructor
        public AnswerChoice(string answer)
        {
            this.answerText = answer;
        }

        // Property to access answerText
        public string AnswerText
        {
            get { return this.answerText; }
            set { this.answerText = value; }
        }

    }
}
