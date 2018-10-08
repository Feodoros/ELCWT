using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingApp
{
    class Inscription
    {
        public const string ConectionFalse = "Нет подключения к интернету, невозможно выполнить проверку обновлений и лицензии.";
        public const string CheckConection = "Проверка соединения...";
        public const string ConectionTrue = "Есть подключение.";
        public const string ConectionMessageFalse = "Нет подключения.";

        public const string line = "__________________________";
        public const string Screen = "Меню";
        public const string SplashScreen = "Splash Screen";

        public const string LicenceRequest = "Запрос лицензии...";
        public const string LicenceAnswer = "Ответ получен.";
        public const string LicenceTrue = "У Вас есть лицензия.";
        public const string LicenceFаlse = "У Вас нет лицензии.";
        public const string LicenceProgramTrue = "Лицензионная программа.";
        public const string LicenceProgramFalse = "Нелицензионная программа.";

        public const string UpdateRequest = "Запрос обновления...";
        public const string UpdateAnswer = "Запрос обновлений завершен.";
        public const string Updated = "Программа обновлена.";
        public const string NotUpdated = "Программа не обновлена.";
        public const string ExistUpdate = "Имеется новое обновление, сейчас оно будет загружено...";
        public const string NoExistUpdate = "Обновления не найдены.";
        public const string UpdateDownload = "Загружаем обновления...";
        public const string UpdateDownloadFinish = "Обновление завершено!";
    }
}
