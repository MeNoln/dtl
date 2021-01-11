using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DataLuna.Back.Infrastructure.Internal;

namespace DataLuna.Back.Infrastructure
{
    public interface IYandexStorage
    {
        Task<string> UploadPlayerImageToCloud(IFormFile image, FolderPathEnum path);
    }
}