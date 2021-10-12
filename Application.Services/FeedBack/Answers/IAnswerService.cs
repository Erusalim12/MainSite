using Application.Dal.Domain.FeedBack;
using System.Collections.Generic;


namespace Application.Services.FeedBack.Answers
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAll();
        void Add(Answer item);
    }
}
