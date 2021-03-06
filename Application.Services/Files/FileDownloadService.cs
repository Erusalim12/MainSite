﻿using System;
using System.IO;
using System.Linq;
using Application.Dal;
using Application.Dal.Infrastructure;
using Microsoft.AspNetCore.Http;
using File = Application.Dal.Domain.Files.File;

namespace Application.Services.Files
{    /// <summary>
     /// Сервис обработки файлов
     /// </summary>
    public partial class FileDownloadService : IFileDownloadService
    {

        #region Fields

        //private readonly IEventPublisher _eventPubisher;
        private readonly IRepository<File> _downloadRepository;
        private readonly IAppFileProvider _fileProvider;
        #endregion

        #region Ctor

        public FileDownloadService(IRepository<File> downloadRepository, IAppFileProvider fileProvider)
        {
            _downloadRepository = downloadRepository;
            _fileProvider = fileProvider;
        }


        #endregion

        #region Methods

        public virtual File GetDownloadByIdOrName(string val)
        {
            if (val == null) return null;
            return _downloadRepository.GetAll.FirstOrDefault(c => c.Id == val || c.Name == val);
        }


        public virtual File GetDownloadByStoredName(string storedName)
        {
            if (string.IsNullOrEmpty(storedName)) return null;

            return _downloadRepository.Get(c => c.Name == storedName);
        }

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>Download</returns>
        public virtual File GetDownloadByGuid(string downloadGuid)
        {
            if (downloadGuid == null)
                return null;

            return _downloadRepository.Get(downloadGuid);
        }

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void DeleteDownload(File download)
        {
            if (download == null)
                throw new ArgumentNullException(nameof(download));

            _downloadRepository.Delete(download);

            //event notification
            //_eventPubisher.EntityDeleted(download);
        }

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void InsertDownload(File download)
        {
            if (download == null)
                throw new ArgumentNullException(nameof(download));

            _downloadRepository.Add(download);

            //event notification
            //_eventPubisher.EntityInserted(download);
        }

        /// <summary>
        /// Updates the download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void UpdateDownload(File download)
        {
            if (download == null)
                throw new ArgumentNullException(nameof(download));

            _downloadRepository.Update(download);

            //event notification
            //_eventPubisher.EntityUpdated(download);
        }

        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Download binary array</returns>
        public virtual byte[] GetDownloadBits(IFormFile file)
        {
            using var fileStream = file.OpenReadStream();
            using var ms = new MemoryStream();
            fileStream.CopyTo(ms);
            var fileBytes = ms.ToArray();
            return fileBytes;
        }

        public virtual string SaveFileInFileSystem(byte[] binaryData, string fileName, string catalog = null)
        {
            var localPath = GetFileLocalPath(fileName, catalog);
            _fileProvider.WriteAllBytes(localPath, binaryData);
            return localPath;
        }
        #endregion

        #region additional methods

        /// <summary>
        /// Get file local path. Used when files stored on file system (not in the database)
        /// </summary>
        /// <param name="fileName">Filename</param>
        /// <param name="fileCatalog">catalog</param> 
        /// <returns>Local file path</returns>
        public string GetFileLocalPath(string fileName, string catalog = null)
        {
            if (catalog == null) catalog = AppMediaDefaults.DefaultPathToFileCatalog;

            var filesDir = _fileProvider.GetAbsolutePath(catalog);
            _fileProvider.CreateDirectory(filesDir);
            return _fileProvider.Combine(filesDir, fileName);
        }


        #endregion
    }


}
