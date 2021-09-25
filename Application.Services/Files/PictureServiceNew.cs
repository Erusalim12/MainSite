using System;
using System.Collections.Generic;
using System.Text;
using Application.Dal;
using Application.Dal.Domain.Files;
using Application.Dal.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Files
{
   public class PictureServiceNew
    {
 

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppFileProvider _fileProvider;
        private readonly IRepository<Picture> _pictureRepository;



 





    }
}
