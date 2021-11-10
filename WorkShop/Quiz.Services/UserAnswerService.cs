using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Services.Contract;
using Quiz.Services.Models;
using QuizSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAnswerService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void AddUserAnswer(string userName, int questionId, int answerId)
        {
            var userId = this.applicationDbContext.Users.Where(x => x.UserName == userName)
                .Select(x => x.Id).FirstOrDefault();

            var userAnswer = applicationDbContext.UserAnswers.FirstOrDefault(x => x.IdentityUserId == userId && x.QuestionId == questionId);
            userAnswer.AnswerId = answerId;
            this.applicationDbContext.SaveChanges();
        }

        public int GetUserResult(string userName, int quizId) 
        {
            var userId = this.applicationDbContext.Users.Where(x => x.UserName == userName)
                .Select(x => x.Id).FirstOrDefault();

            var totalPoint = this.applicationDbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);
            return totalPoint;
        }
    }
}
