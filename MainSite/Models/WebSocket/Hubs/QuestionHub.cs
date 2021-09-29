using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace MainSite.Models.WebSocket.Hubs
{
    public class QuestionHub : Hub<IQuestionHub>
    {
        public QuestionHub()
        {
        }

        public async Task QuestionScoreChange(string questionId, int score)
        {
            this.Clients.Group("Group").ToString();
        }

        public async Task JoinQuestionGroup(string userId, bool isAdmin)
        {
            Console.WriteLine("Коннект {0}, {1}", userId, isAdmin);
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
        public async Task LeaveQuestionGroup(string userId)
        {
            Console.WriteLine("Коннект Удаление");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

    }
}  
