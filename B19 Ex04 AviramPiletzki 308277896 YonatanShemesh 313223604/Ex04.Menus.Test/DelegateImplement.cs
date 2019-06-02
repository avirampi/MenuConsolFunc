using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateImplement : MainMenu
    {
        public DelegateImplement(string title) : base(title)
        {
            MenuItem showDateAndTime = new MenuItem("show Date/Time");
            MenuItem versionAndDigits = new MenuItem("Show Version and Digits");

            MenuItem showTime = new MenuItem("Show Current Time:");
            showTime.ClickOccured += new ClickEventHandler(ShowTime_OnClick);
            MenuItem showDate = new MenuItem("Show Current Date:");
            showDate.ClickOccured += new ClickEventHandler(ShowDate_OnClick);
            MenuItem version = new MenuItem("Show Version");
            version.ClickOccured += new ClickEventHandler(ShowVersion_OnClick);
            MenuItem digits = new MenuItem("Count Digits");
            digits.ClickOccured += new ClickEventHandler(CountDigits_OnClick);

            AddToMenu(showDateAndTime);
            AddToMenu(versionAndDigits);

            AddToSubMenu(showDateAndTime, showTime);
            AddToSubMenu(showDateAndTime, showDate);
            AddToSubMenu(versionAndDigits, digits);
            AddToSubMenu(versionAndDigits, version);
        }

        private void CountDigits_OnClick()
        {
            string input;
            int counter = 0;
            System.Console.WriteLine("Please Enter A sentence");
            input = Console.ReadLine();
            foreach (char ch in input)
            {
                if (ch >= '0' && ch <= '9')
                {
                    counter++;
                }
            }

            System.Console.WriteLine("There are " + counter.ToString() + " digits in your sentence");
            Console.ReadLine();
        }

        private void ShowVersion_OnClick()
        {
            System.Console.WriteLine("Version: 19.2.4.32");
            System.Console.WriteLine("Press any Key to continue");
            Console.ReadLine();
        }

        private void ShowTime_OnClick()
        {
            System.Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
            System.Console.WriteLine("Press any Key to continue");
            Console.ReadLine();
        }

        private void ShowDate_OnClick()
        {
            System.Console.WriteLine(DateTime.Now.ToString("MM/d/yyyy"));
            System.Console.WriteLine("Press any Key to continue");
            Console.ReadLine();
        }
    }
}
