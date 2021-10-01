using System;
using System.Threading.Tasks;

namespace MainSite.Models.WebSocket.Hubs
{
    public interface IQuestionHub
    {
        Task QuestionScoreChange(string questionId, int score);

        Task AnswerCountChange(string questionId, int answerCount);

        //Task AddQuestionChange();
    }
}
