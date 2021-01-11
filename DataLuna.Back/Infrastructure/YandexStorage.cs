using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DataLuna.Back.Infrastructure.Internal;
using AspNetCore.Yandex.ObjectStorage;

namespace DataLuna.Back.Infrastructure
{
    public class YandexStorage : IYandexStorage
    {
        private const string PLAYERS_FOLDER_PATH = "players";
        private const string TEAMS_FOLDER_PATH = "teams";
        private readonly YandexStorageService _yandexProvider;
        public YandexStorage(YandexStorageService yandexProvider)
            => (_yandexProvider) = (yandexProvider);

        public async Task<string> UploadPlayerImageToCloud(IFormFile image, FolderPathEnum path)
        {
            string folder = path switch
            {
                FolderPathEnum.Player => PLAYERS_FOLDER_PATH,
                FolderPathEnum.Team => TEAMS_FOLDER_PATH,
                _ => throw new Exception("Unhandled folder path."),
            };

            using var fileStream = image.OpenReadStream();
            return await _yandexProvider.PutObjectAsync(fileStream, string.Format("{0}/{1}", folder, image.FileName));
        }
    }
}