using Application.Dal.Domain.Users;
using Application.Services.Users;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MainSite.Models.WebSocket.Hubs
{
    public class QuestionHub : Hub<IQuestionHub>
    {
        private readonly IUsersService _userService;
        public QuestionHub(IUsersService userService)
        {
            _userService = userService;
        }

        public async Task QuestionScoreChange(string questionId, int score)
        {
        }

        public async Task CreateQuestionGroup(string questionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, questionId);
        }
        public async Task RemoveQuestionGroup(string questionId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, questionId);
        }

        public async Task CreateAdminGroup()
        {
            if (isAdminUser()) await Groups.AddToGroupAsync(Context.ConnectionId, AppUserDefaults.AdministratorsRoleName);
        }

        public async Task RemoveAdminGroup()
        {
            if (isAdminUser())  await Groups.RemoveFromGroupAsync(Context.ConnectionId, AppUserDefaults.AdministratorsRoleName);
        }

        private bool isAdminUser()
        {
            return _userService.IsAdmin(_userService.GetUserBySystemName(Context.User));
        }

    }
}  
