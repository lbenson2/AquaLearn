using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
   public class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }

        public Quiz()
        {
            Name = "Quiz";
        }
    }
}
