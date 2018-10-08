using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingApp
{
    class StartScreen
    {
        public bool Update;
        public bool Connection;
        public bool Licence;

        public void Screen()
        {
            Console.WriteLine(Inscription.Screen);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Inscription.line);
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (Connection)
            {
                if (Update)
                {
                    Console.WriteLine(Inscription.Updated);
                }
                else
                {
                    Console.WriteLine(Inscription.NotUpdated);
                }

                if (Licence)
                {
                    Console.WriteLine(Inscription.LicenceProgramTrue);
                }
                else
                {
                    Console.WriteLine(Inscription.LicenceProgramFalse);
                }
            }
            else
            {
                Console.WriteLine(Inscription.ConectionMessageFalse);
            }
        }
    }
}
