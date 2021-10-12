using Application.Dal.Domain.FeedBack;
using Application.Dal.Domain.Users;
using Application.Services.FeedBack.Answers;
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
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IHubContext<QuestionHub, IQuestionHub> _hubContext;
        public QuestionController(IHubContext<QuestionHub, IQuestionHub> questionHub, IUsersService usersService, IQuestionService questionService, IAnswerService answerService)
        {
            _hubContext = questionHub;
            _questionService = questionService;
            _userService = usersService;
            _answerService = answerService;
        }

        [HttpGet("question")]
        public IEnumerable GetQuestions()
        {
            var isAdmin = _userService.IsAdmin(_userService.GetUserBySystemName(HttpContext.User));

            var questions = _questionService.GetAll().Where(s => s.CustomerId == HttpContext.User.Identity.Name || isAdmin).Select(a => new {
                Id = a.Id,
                CustomerId = a.CustomerId,
                AnswerCount = a.Answers.Count
            });
            return questions;
        }

        [HttpGet("{id}")]
        public ActionResult GetQuestion(string id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null) return new JsonResult(null);

            return new JsonResult(question);
        }

        [HttpPost("addQuestion")]
        public async Task<ActionResult> AddQuestionAsync(Question question)
        {
            if (question != null)
            {
                var answer = question.Answers.FirstOrDefault();
                if(answer != null)
                { 
                    answer.Id = Guid.NewGuid().ToString();
                    answer.Date = DateTime.Now;
                    answer.SenderName = User.Identity.Name;
                    answer.IsAdmin = _userService.IsAdmin(_userService.GetUserBySystemName(User));
                }
                _questionService.Add(question);

                await _hubContext.Clients.Group(AppUserDefaults.AdministratorsRoleName).AddQuestionChange(question);
                await _hubContext.Clients.Group(question.Id).AddQuestionChange(question);

                return new JsonResult(new { Id = question.Id, Title = question.Title, AnswerCount =  question.Answers.Count() });
            }

            return new JsonResult(null);
        }

        [HttpPost("addAnswer")]
        public async Task<ActionResult> AddAnswerAsync(Answer answer)
        {
            var question = _questionService.GetAll().SingleOrDefault(t => t.Id == answer.QuestionId);
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }
            else
            {

                answer.Id = Guid.NewGuid().ToString();
                answer.Date = DateTime.Now;
                answer.SenderName = User.Identity.Name;
                answer.IsAdmin = _userService.IsAdmin(_userService.GetUserBySystemName(User));

                _answerService.Add(answer);
                // Notify every client
                await _hubContext.Clients.Group(answer.QuestionId).AnswerCountChange(question.Id, question.Answers.Count);
                await _hubContext.Clients.Group(answer.QuestionId).AnswerAdded(answer);

                return new JsonResult(answer);
            }
        }

        [HttpPost("deleteQuestion")]
        public async Task<ActionResult> DeleteQuestionAsync(string questionId)
        {
            var question = _questionService.GetQuestionById(questionId);
            if (question == null)
            {
                throw new ArgumentNullException(questionId);
            }
            else
            {
                await _hubContext.Clients.Group(questionId).DeleteQuestionChange();
                _questionService.Delete(questionId);

                return new JsonResult(new { Succes = "Диалог успешно завершен" });
            }
        }

    }
}
