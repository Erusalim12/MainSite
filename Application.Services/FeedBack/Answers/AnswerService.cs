using Application.Dal;
using Application.Dal.Domain.FeedBack;
using System;
using System.Collections.Generic;

namespace Application.Services.FeedBack.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> _repository;
        public AnswerService(IRepository<Answer> repository)
        {
            _repository = repository;
        }

        public void Add(Answer answer)
        {
            if (answer != null) _repository.Add(answer);
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
