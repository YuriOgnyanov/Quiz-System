﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Models
{
    public class QuizinputModel
    {
        public string UserId { get; set; }
        public int QuizId { get; set; }
        public List<QuestionInputModel> Questions { get; set; }

    }
}
