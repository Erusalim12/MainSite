using Application.Dal;
using Application.Dal.Domain.FeedBack;
using Application.Services.FeedBack.Answers;
using System;
using System.Collections.Generic;

namespace Application.Services.FeedBack.Questions
{
    public class QuestionService: IQuestionService
    {
        private readonly IRepository<Question> _repository;
        private readonly IAnswerService _answerService;
        public QuestionService(IRepository<Question> repository, IAnswerService answerService)
        {
            _repository = repository;
            _answerService = answerService;
        }

        public void Add(Question question)
        {
            if (question != null)
            {
                foreach (var answer in question.Answers) {
                    answer.Id = Guid.NewGuid().ToString();
                }
                _repository.Add(question);
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return _repository.GetAll;
        }
    }
}
