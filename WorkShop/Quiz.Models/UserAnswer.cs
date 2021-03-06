using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Quiz.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUsers { get; set; }

        //public int QuizId { get; set; }
        //public Quiz Quiz { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
