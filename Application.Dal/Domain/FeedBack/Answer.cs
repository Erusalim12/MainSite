using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Dal.Domain.FeedBack
{
    public class Answer: BaseEntity
    {
        public string Message { get; set; }
        public string QuestionId { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }

        public string SenderName { get; set; }

        public DateTime Date { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsVisit { get; set; } = false;
    }
}
