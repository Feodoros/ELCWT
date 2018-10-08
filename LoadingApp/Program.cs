using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            StartScreen Menu = new StartScreen();

            bool ConnectionTrue = RandomValues(80);
            bool LicenceTrue = RandomValues(45);
            bool UpdateTrue = RandomValues(75);

            //CTS лицензии.
            CancellationTokenSource LicenceCTS = new CancellationTokenSource();
            CancellationToken LicenceToken = LicenceCTS.Token;
            if (LicenceTrue != true)
                LicenceCTS.Cancel();

            //CTS обновления.
            CancellationTokenSource UpdateCTS = new CancellationTokenSource();
            CancellationToken UpdateToken = UpdateCTS.Token;
            if (UpdateTrue != true)
                UpdateCTS.Cancel();

            //CTS соединения.
            CancellationTokenSource ConectionCTS = new CancellationTokenSource();
            CancellationToken ConectionToken = ConectionCTS.Token;
            if (ConnectionTrue != true)
                ConectionCTS.Cancel();


            // Splash Screen
            Task SplashScreen = new Task(() =>
            {
                Console.WriteLine(Inscription.SplashScreen);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Inscription.line);
                Console.ForegroundColor = ConsoleColor.White;
            });
            SplashScreen.Start();


            //Проверка соединения=>    
            //1
            Task WriteAboutConection = SplashScreen.ContinueWith(task =>
            {
                Console.WriteLine(Inscription.CheckConection);               
            });

            //2
            Task ConectionCheck = WriteAboutConection.ContinueWith(task =>
            {
                Menu.Connection = true;
                Console.WriteLine(Inscription.ConectionTrue);
            }, ConectionToken);

            //3
            Task ConectionFalse = ConectionCheck.ContinueWith(task =>
            {
                Thread.Sleep(2000);
                Menu.Connection = false;
                Console.WriteLine(Inscription.ConectionFalse);
                Thread.Sleep(3000);
            }, TaskContinuationOptions.OnlyOnCanceled);


            //Проверка лицензии=>
            //1
            Task WriteAboutLicence = ConectionCheck.ContinueWith(task =>
            {
                Console.WriteLine(Inscription.LicenceRequest);
            }, TaskContinuationOptions.NotOnCanceled);

            //2
            Task LicenceTrueOrFalse = ConectionCheck.ContinueWith(task =>
            {
                Thread.Sleep(5000);
                Menu.Licence = true;
                Console.WriteLine(Inscription.LicenceAnswer);
                Console.WriteLine(Inscription.LicenceTrue);
                Thread.Sleep(3000);
            }, LicenceToken, TaskContinuationOptions.NotOnCanceled, TaskScheduler.Default);

            //3
            Task LicenceFalse = LicenceTrueOrFalse.ContinueWith(task =>
            {
                Thread.Sleep(5000);
                Menu.Licence = false;
                Console.WriteLine(Inscription.LicenceAnswer);
                Console.WriteLine(Inscription.LicenceFаlse);
                Thread.Sleep(3000);
            }, TaskContinuationOptions.OnlyOnFaulted); 


            //Проверка обновлений=>
            //1
            Task WriteAboutUpdates = ConectionCheck.ContinueWith(task =>
            {
                Console.WriteLine(Inscription.UpdateRequest);
            }, TaskContinuationOptions.NotOnCanceled);

            //2
            Task UpdateTrueOrFalse = WriteAboutUpdates.ContinueWith(task =>
            {

                Thread.Sleep(3000);
                Menu.Update = true;
                Console.WriteLine(Inscription.UpdateAnswer);
                Console.WriteLine(Inscription.ExistUpdate);
            }, UpdateToken, TaskContinuationOptions.NotOnCanceled, TaskScheduler.Default);

            //3
            Task UpdateFalse = UpdateTrueOrFalse.ContinueWith(task =>
            {
                Thread.Sleep(3000);
                Menu.Update = false;
                Console.WriteLine(Inscription.UpdateAnswer);
                Console.WriteLine(Inscription.NoExistUpdate);
                Thread.Sleep(3000);
            }, TaskContinuationOptions.OnlyOnFaulted);

            //4
            Task Updating = UpdateTrueOrFalse.ContinueWith(task =>
            {
                Console.WriteLine(Inscription.UpdateDownload);
                Thread.Sleep(3000);
                Console.WriteLine(Inscription.UpdateDownloadFinish);
                Thread.Sleep(10000);
            }, TaskContinuationOptions.NotOnCanceled);




            //Отрисовка меню.
            Action MenuAction = () =>
            {
                Console.Clear();
                Menu.Screen();
            };


            Task DrawMenu = Task.Factory.ContinueWhenAll(new[] { ConectionFalse, UpdateTrueOrFalse, ConectionCheck, LicenceTrueOrFalse }, tasks =>
            {
                MenuAction();
            });

            Console.ReadKey();
        }


        public static bool RandomValues(int per)
        {
            Random rand = new Random();
            return rand.NextDouble() < per / 100.0;
        }
    }
}

