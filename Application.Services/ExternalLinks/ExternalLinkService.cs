using Application.Dal;
using Application.Dal.Domain.ExternalLinks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.ExternalLinks
{
    public class ExternalLinkService : IExternalLinkService
    {
        private readonly IRepository<ExternalLink> _repository;

        public ExternalLinkService(IRepository<ExternalLink> repository)
        {
            _repository = repository;
        }

        public void DeleteItem(ExternalLink ex)
        {
            if (ex == null) throw new NullReferenceException("menu item is null");

            _repository.Delete(ex);
        }

        public ExternalLink Get(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id is null");
            return _repository.Get(id);
        }

        public IEnumerable<ExternalLink> GetAll()
        {
            return _repository.GetAll;
        }

        public void InsertItem(ExternalLink ex)
        {
            ex.Order = _repository.GetAll.Count() + 1;
            _repository.Add(ex);
        }

        public void UpdateItem(ExternalLink ex)
        {
            if (ex == null) throw new NullReferenceException("menu item is null");

            _repository.Update(ex);
        }
    }
}
