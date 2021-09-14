﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Application.Dal;
using Microsoft.AspNetCore.Http;

namespace MainSite.ViewModels.News
{
    public class NewsItemViewModel
    {
        public NewsItemViewModel()
        {
            UploadedFiles = new List<IFormFile>();
        }

        [Display(Name = "Идентификатор")]
        public string Id { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Название"), Required]
        public string Header { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public string CategoryId { get; set; }
        [Display(Name = "Текущая категория")]
        public string Category { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Дата последнего редактирования")]
        public DateTime LastChangeDate { get; set; }

        public string UrlIcon
        {
            get
            {
                //TODO: перенести в HtmlExtensions
                return IsMessage ? ImagePath.New.MissingFiles : ImagePath.New.AvailabilityFiles;
            }
        }

        public bool IsMessage { get; set; }

        public ICollection<FileViewModel> Files { get; set; }

 
        

        [JsonIgnore]
        public ICollection<IFormFile> UploadedFiles { get; set; }

        public bool IsAdvancedEditor { get; set; }

    }
}
