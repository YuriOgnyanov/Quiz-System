﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Contract
{
    public interface IQuestionService
    {
        int Add(string title, int quizId);
    }
}
