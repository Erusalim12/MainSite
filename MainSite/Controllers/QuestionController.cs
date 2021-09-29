using Application.Dal.Domain.Users;
using Application.Services.Users;
using MainSite.Models.WebSocket;
using MainSite.Models.WebSocket.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Concurrent;
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
        private static List<Question> questions = new List<Question> {
            new Question {
                Id = Guid.Parse("b00c58c0-df00-49ac-ae85-0a135f75e01b"),
                Title = "Welcome",
                Body = "Welcome to the _mini Stack Overflow_ rip-off!\nThis will help showcasing **SignalR** and its integration with **Vue**",
                Answers = new List<Answer> { new Answer { Body = "Sample answer" } }
            },
            new Question
            {
                Id = Guid.Parse("b00c58c0-df00-49ac-ae85-0a135f75e02b"),
                Title = "GoodBuy",
                Body = "Sorry, this element have deleted because I dont speack English",
                Answers = new List<Answer> { new Answer { Body = "Base answer" } }
            }
         };
        private List<string> admins = new List<string>();

        private readonly IHubContext<QuestionHub, IQuestionHub> _hubContext;
        public QuestionController(IHubContext<QuestionHub, IQuestionHub> questionHub, IUsersService usersService)
        {
            _hubContext = questionHub;
            _userService = usersService;
        }

        [HttpGet("question")]
        public IEnumerable GetQuestions()
        {
            return questions.Select(q => new {
                Id = q.Id,
                Title = q.Title,
                Body = q.Body,
                Score = q.Score,
                AnswerCount = q.Answers.Count
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetQuestion(Guid id)
        {
            var question = questions.SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            return new JsonResult(question);
        }

        [HttpPost("addQuestion")]
        public Question AddQuestion([FromBody] Question question)
        {
            question.Id = Guid.NewGuid();
            question.Answers = new List<Answer>();
            questions.Add(question);
            return question;
        }

        [HttpPost("{id}/answer")]
        public async Task<ActionResult> AddAnswerAsync(Guid id, [FromBody] Answer answer)
        {
            var question = questions.SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            answer.Id = Guid.NewGuid();
            answer.QuestionId = id;
            question.Answers.Add(answer);

            // Notify every client
            await _hubContext.Clients.All.AnswerCountChange(question.Id, question.Answers.Count);

            return new JsonResult(answer);
        }

        [HttpPatch("{id}/upvote")]
        public async Task<ActionResult> UpvoteQuestionAsync(Guid id)
        {
            var question = questions.SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            // Warning, this increment isnt thread-safe! Use Interlocked methods
            question.Score++;

            // Notify every client
            //var groupChat = admins.
            await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);
            //await _hubContext.Clients.Users(new List<string> { "25211647-9c0e-48ab-8952-c64c9c3afd55", "25211647-9c0e-48ab-8952-c64c9c3afd55", "25211647-9c0e-48ab-8952-c64c9c3afd55" }).QuestionScoreChange(question.Id, question.Score);
            //await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);

            return new JsonResult(question);
        }

        [HttpPatch("{id}/downvote")]
        public async Task<ActionResult> DownvoteQuestionAsync(Guid id)
        {
            var question = questions.SingleOrDefault(t => t.Id == id);
            if (question == null) return NotFound();

            // Warning, this isnt really atomic
            question.Score--;

            // Notify every client
            await _hubContext.Clients.All.QuestionScoreChange(question.Id, question.Score);

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
