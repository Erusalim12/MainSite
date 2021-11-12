using Application.Dal.Domain.ExternalLinks;
using System.Collections.Generic;

namespace Application.Services.ExternalLinks
{
    public interface IExternalLinkService
    {
        ExternalLink Get(string id);
        void InsertItem(ExternalLink ex);
        void DeleteItem(ExternalLink ex);
        void UpdateItem(ExternalLink ex);
        IEnumerable<ExternalLink> GetAll();
    }
}
