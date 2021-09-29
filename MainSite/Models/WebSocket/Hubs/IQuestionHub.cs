using System;
using System.Threading.Tasks;

namespace MainSite.Models.WebSocket.Hubs
{
    public interface IQuestionHub
    {
        Task QuestionScoreChange(Guid questionId, int score);

        Task AnswerCountChange(Guid questionId, int answerCount);
    }
}
