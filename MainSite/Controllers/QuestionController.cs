using Application.Dal.Domain.FeedBack;
using Application.Dal.Domain.Users;
using Application.Services.FeedBack.Customers;
using Application.Services.FeedBack.Questions;
using Application.Services.Users;
using MainSite.Models.WebSocket.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly IUsersService _userService;
        private readonly ICustomerService _cusomerService;
        private readonly IQuestionService _questionService;

        private readonly IHubContext<QuestionHub, IQuestionHub> _hubContext;
        public QuestionController(IHubContext<QuestionHub, IQuestionHub> questionHub, IUsersService usersService, ICustomerService customerService, IQuestionService questionService)
        {
            _hubContext = questionHub;
            _questionService = questionService;
            _cusomerService = customerService;
            _userService = usersService;
        }

        [HttpGet("question")]
        public IEnumerable GetQuestions()
        {
            return _questionService.GetAll().Select(q => new {
                Id = q.Id,
                Title = q.Title,
                AnswerCount = q.Answers.Count
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetQuestion(string id)
        {
            var question = _questionService.GetAll().SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            return new JsonResult(question);
        }

        [HttpPost("addQuestion")]
        public Question AddQuestion( Question question)
        {
            _questionService.Add(question);

            return question;
        }

        [HttpPost("{id}/answer")]
        public async Task<ActionResult> AddAnswerAsync(string id, [FromBody] Answer answer)
        {
            var question = _questionService.GetAll().SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            answer.Id = Guid.NewGuid().ToString();
            answer.QuestionId = id;
            question.Answers.Add(answer);

            // Notify every client
            await _hubContext.Clients.All.AnswerCountChange(question.Id, question.Answers.Count);

            return new JsonResult(answer);
        }

        [HttpPatch("{id}/upvote")]
        public async Task<ActionResult> UpvoteQuestionAsync(string id)
        {
            var question = _questionService.GetAll().SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            // Warning, this increment isnt thread-safe! Use Interlocked methods
            //question.Score++;

            // Notify every client
            //var groupChat = admins.
            //await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);
            //await _hubContext.Clients.Users(new List<string> { "25211647-9c0e-48ab-8952-c64c9c3afd55", "25211647-9c0e-48ab-8952-c64c9c3afd55", "25211647-9c0e-48ab-8952-c64c9c3afd55" }).QuestionScoreChange(question.Id, question.Score);
            //await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);

            return new JsonResult(question);
        }

        [HttpPatch("{id}/downvote")]
        public async Task<ActionResult> DownvoteQuestionAsync(string id)
        {
            var question = _questionService.GetAll().SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            // Warning, this isnt really atomic
            //question.Score--;

            // Notify every client
            //await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);

            return new JsonResult(question);
        }

        /*private List<string> GetListUserIdsBySendingMessage()
        {
            admins = _userService.GetUserIdsByRoles(new List<string> { AppUserDefaults.AdministratorsRoleName }).ToList();
            var newGroupUsers = new List<string>();
            newGroupUsers.AddRange(admins);
            newGroupUsers.Add(_userService.GetUserBySystemName(HttpContext.User).Id);

            return newGroupUsers;
        }*/
    }
}
