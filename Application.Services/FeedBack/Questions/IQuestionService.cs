using Application.Dal.Domain.FeedBack;
using System.Collections.Generic;

namespace Application.Services.FeedBack.Questions
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        void Add(Question question);

        Question GetQuestionById(string id, bool isAdmin);
        void Delete(string id);
    }
}
