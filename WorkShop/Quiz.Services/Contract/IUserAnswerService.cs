using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Contract
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string userName, int questionId, int answerId);

        int GetUserResult(string userName, int quizId);
    }
}
