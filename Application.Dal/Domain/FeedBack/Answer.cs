using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dal.Domain.FeedBack
{
    public class Answer: BaseEntity
    {
        public string Message { get; set; }
        public string QuestionId { get; set; }
    }
}
