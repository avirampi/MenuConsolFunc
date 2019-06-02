using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class InterfaceImplement
    {
        private MainMenu m_MainMenu;

        public InterfaceImplement(string i_Title)
        {
            m_MainMenu = new MainMenu(i_Title);
            GeneralMenuItem showDateAndTime = new GeneralMenuItem("show Date/Time");
            GeneralMenuItem versionAndDigits = new GeneralMenuItem("Show Version and Digits");
            ShowTime showTime = new ShowTime("Show Current Time:");
            ShowDate showDate = new ShowDate("Show Current Date:");
            ShowVersion version = new ShowVersion("Show Version");
            ShowCountDigits digits = new ShowCountDigits("Count Digits");

            m_MainMenu.AddToMenu(showDateAndTime);
            m_MainMenu.AddToMenu(versionAndDigits);

            m_MainMenu.AddToSubMenu(showDateAndTime, showTime);
            m_MainMenu.AddToSubMenu(showDateAndTime, showDate);
            m_MainMenu.AddToSubMenu(versionAndDigits, digits);
            m_MainMenu.AddToSubMenu(versionAndDigits, version);
        }

        public void Show()
        {
            m_MainMenu.Show();
        }

        public class GeneralMenuItem : IMenuItems
        {
            private string m_Title;

            public GeneralMenuItem(string i_Title)
            {
                m_Title = i_Title;
            }

            public string Title
            {
                get { return m_Title; }
                set { m_Title = value; }
            }

            public void OnClick()
            {
                System.Console.WriteLine("This Menu Is Currently Empty");
                System.Console.WriteLine("Press any Key to continue");
                Console.ReadLine();
            }
        }

        public class ShowTime : IMenuItems
        {
            private string m_Title;

            public ShowTime(string i_Title)
            {
                m_Title = i_Title;
            }

            public string Title
            {
                get { return m_Title; }
                set { m_Title = value; }
            }

            public void OnClick()
            {
                System.Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
                System.Console.WriteLine("Press any Key to continue");
                Console.ReadLine();
            }
        }

        public class ShowDate : IMenuItems
        {
            private string m_Title;

            public ShowDate(string i_Title)
            {
                m_Title = i_Title;
            }

            public string Title
            {
                get { return m_Title; }
                set { m_Title = value; }
            }

            public void OnClick()
            {
                System.Console.WriteLine(DateTime.Now.ToString("MM/d/yyyy"));
                System.Console.WriteLine("Press any Key to continue");
                Console.ReadLine();
            }
        }

        public class ShowVersion : IMenuItems
        {
            private string m_Title;

            public ShowVersion(string i_Title)
            {
                m_Title = i_Title;
            }

            public string Title
            {
                get { return m_Title; }
                set { m_Title = value; }
            }

            public void OnClick()
            {
                System.Console.WriteLine("Version: 19.2.4.32");
                System.Console.WriteLine("Press any Key to continue");
                Console.ReadLine();
            }
        }

        public class ShowCountDigits : IMenuItems
        {
            private string m_Title;

            public ShowCountDigits(string i_Title)
            {
                m_Title = i_Title;
            }

            public string Title
            {
                get { return m_Title; }
                set { m_Title = value; }
            }

            public void OnClick()
            {
                countDigits();
            }

            private static void countDigits()
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
        }
    }
}
