using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.LiteScript.Compiler.Core
{
    public sealed class Locale
    {
        public Dictionary<string, string> LocaleKeyPair { get; private set; }

        public Locale(string locale)
        {
            LoadLocale(locale);
        }

        public void LoadLocale(string locale)
        {
            try
            {
                string[] fileRd = File.ReadAllLines(Environment.CurrentDirectory + @"\locale\" + locale + ".lng");
                foreach (var ln in fileRd)
                {
                    LocaleKeyPair.Add(ln.Split('=')[0], ln.Split('=')[1]);
                }
            }
            catch
            {
                Console.WriteLine("Unable to load locale! Check settings or locale file!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
