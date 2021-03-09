﻿using System;
using System.Collections.Generic;
using System.Text;
using Application.Dal;
using Application.Dal.Domain.News;
using Application.Services.News;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class NewsServiceTests
    {
        [TestCase("")]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetNewsItem_RequestWithInvalidId_ReturnNull(string id)
        {
            Mock<IRepository<NewsItem>> mock = new Mock<IRepository<NewsItem>>();

            NewsService newsService = new NewsService(mock.Object);
            NewsItem result = newsService.GetNewsItem(id);

            Assert.IsTrue(result == null);
        }

        [Test]
        public void GetNewsItem_RequestOneExistNewsItem_ReturnNewsItem()
        {
            string guid = Guid.NewGuid().ToString();

            Mock<IRepository<NewsItem>> mock = new Mock<IRepository<NewsItem>>();
            mock.Setup(m => m.Get(guid)).Returns(new NewsItem()
            {
                Id = guid,
                Category = null,
                Description = "Description1",
                Files = null,
                Header = "Header1",
            });

            NewsService newsService = new NewsService(mock.Object);
            NewsItem result = newsService.GetNewsItem(guid);

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Id == guid);
        }
    }
}
