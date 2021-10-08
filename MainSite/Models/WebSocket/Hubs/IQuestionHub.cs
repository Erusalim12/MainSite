using Application.Dal.Domain.FeedBack;
using System.Threading.Tasks;

namespace MainSite.Models.WebSocket.Hubs
{
    public interface IQuestionHub
    {
        Task QuestionScoreChange(string questionId, int score);

        Task AnswerCountChange(string questionId, int answerCount);

        Task AnswerAdded(Answer answer);

        Task AddQuestionChange(Question question);

        Task DeleteQuestionChange();
    }
}
