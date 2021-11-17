using Application.Dal.Domain.FeedBack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Dal.Repositories
{
    public class FeedBackRepository : EfRepository<Question>
    {
        public FeedBackRepository(ApplicationContext context) : base(context)
        {
        }
        public Question GetQuestion(string id, bool isAdmin = false)
        {
            return _context.Questions.Include(s => s.Answers.OrderByDescending(w => w.Date)).FirstOrDefault(c => c.Id == id && (c.EndDate == null || isAdmin));
        }

        public override IEnumerable<Question> GetAll
        {
            get
            {
                return _context.Set<Question>().Include(newsItem => newsItem.Answers);
            }
        }

    }
}
