using System;
using System.IO;
using System.Threading.Tasks;
using DataLuna.Back.Infrastructure.Internal;

namespace DataLuna.Back.Infrastructure
{
    public interface IYandexStorage
    {
        Task<string> UploadPlayerImageToCloud(Stream fileStream, string fileName, FolderPathEnum path);
    }
}