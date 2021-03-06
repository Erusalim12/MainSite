﻿using System.Collections.Generic;
using Application.Dal.Domain.Files;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Files
{
    public interface IFileDownloadService
    {
        /// <summary>
        /// Gets a download by GUID or name
        /// </summary>
        /// <param name="val">value for search</param>
        /// <returns>Download</returns>
        File GetDownloadByIdOrName(string val);

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>Download</returns>
        File GetDownloadByGuid(string downloadGuid);

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        void DeleteDownload(File download);

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        void InsertDownload(File download);

        /// <summary>
        /// Updates the download
        /// </summary>
        /// <param name="download">Download</param>
        void UpdateDownload(File download);

        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Download binary array</returns>
        byte[] GetDownloadBits(IFormFile file);

        /// <summary>
        /// Save file into selected directory on filesystem
        /// </summary>
        /// <param name="binaryData">file binary data</param>
        /// <param name="fileName">file name</param>

        string SaveFileInFileSystem(  byte[] binaryData, string fileName,string catalog=null);

        string GetFileLocalPath(string fileName, string catalog = null);

        /// <summary>
        /// Get download by storedName
        /// </summary>
        /// <param name="storedName">file name</param>
        /// <returns></returns>
        File GetDownloadByStoredName(string storedName);
    }
}
