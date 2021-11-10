using Quiz.Services.Contract;
using Quiz.Data;
using Quiz.Models;
using System;
using QuizSystem.Data;
using Quiz.Services.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public QuizService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            this.applicationDbContext.Quizes.Add(quiz);
            this.applicationDbContext.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int quizId) 
        {
            var quiz = this.applicationDbContext.Quizes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel
            {
                Id = quizId,
                Title = quiz.Title,
                Questions = quiz.Questions.Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Answers = x.Answers.Select(x => new AnswerViewModel
                    {
                        Id = x.Id,
                        Title = x.Title
                    })
                })
            };

            return quizViewModel;
        }

        public IEnumerable<UserQuizViewModel> GetQuizesByUserName(string userName)
        {
            var quizes = applicationDbContext.Quizes.Select(x => new UserQuizViewModel
            {
                QuizId = x.Id,
                Title = x.Title,
            }).ToList();

            foreach (var quiz in quizes)
            {
                var questioncount = applicationDbContext.UserAnswers
                    .Count(x => x.IdentityUsers.UserName == userName && x.Question.QuizId == quiz.QuizId);

                if (questioncount == 0)
                {
                    quiz.Status = QuizStatus.NotStarted;
                    continue;
                }

                var answerQuestion = applicationDbContext.UserAnswers
                    .Count(x => x.IdentityUsers.UserName == userName && x.Question.QuizId == quiz.QuizId && x.AnswerId.HasValue);

                if (answerQuestion == questioncount)
                {
                    quiz.Status = QuizStatus.Finished;
                }
                else
                {
                    quiz.Status = QuizStatus.InProgress;
                }
            }

            return quizes;
        }

        public void StartQuiz(string userName, int quizId)
        {
            if (applicationDbContext.UserAnswers.Any(x => x.IdentityUsers.UserName == userName && x.Question.QuizId == quizId))
            {
                return;
            }

            var userId = this.applicationDbContext.Users.Where(x => x.UserName == userName)
                .Select(x => x.Id).FirstOrDefault();

            var questions = applicationDbContext.Questions
                .Where(x => x.QuizId == quizId)
                .Select(x => new { x.Id })
                .ToList();
            foreach (var question in questions)
            {
                applicationDbContext.UserAnswers.Add(new UserAnswer 
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question.Id,
                });
            }

            applicationDbContext.SaveChanges();
        }
    }
}
