using System;
using System.Collections.Generic;

namespace MainSite.Areas.Admin.Models.Users
{
    /// <summary>
    /// Модель для отображения связи пользователь-список присвоеных ролей
    /// </summary>
    public class UserModel : BaseAppEntityModel
    {
        public UserModel()
        {
            UserRoles = new List<string>();
            //заглушка, т.к. неизвестно что отображать
            MessagesCount = -1;
        }
        public string UserName { get; set; }
        public string SystemName { get; set; }

        public string FullName { get; set; }
        /// <summary>
        /// Последний адрес с которого заходил пользователь
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// Список ролей пользователя
        /// </summary>
        public IEnumerable<string> UserRoles { get; set; }
        /// <summary>
        /// Количество сообщений пользователя
        /// </summary>
        public int MessagesCount { get; set; }
        /// <summary>
        /// Дата последнего входа
        /// </summary>
        public DateTime? LastVisitDate { get; set; }

    }
}