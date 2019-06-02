using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private string m_Title = null;
        private string m_MenuLevel = null;
        private List<MenuItem> m_MenuItems = null;
        private Stack<List<MenuItem>> m_MenuListItemsStack;
        private Stack<string> m_MenuTitleStack;
        private Dictionary<MenuItem, List<MenuItem>> m_AllMeunItems;

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_MenuListItemsStack = new Stack<List<MenuItem>>();
            m_MenuTitleStack = new Stack<string>();
            m_AllMeunItems = new Dictionary<MenuItem, List<MenuItem>>();
        }

        private string Level
        {
            get { return m_MenuLevel; }
            set { m_MenuLevel = value; }
        }

        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                dealCurrentMenu(out exit);
            }
        }

        public void AddToMenu(MenuItem i_MenuItem)
        {
            ////There are no Items At The Menu
            if (m_MenuItems == null)
            {
                m_MenuItems = new List<MenuItem>();
                m_MenuItems.Add(new MenuItem("Exit"));
            }

            m_MenuItems.Add(i_MenuItem);
            m_AllMeunItems.Add(i_MenuItem, null);
        }

        public void AddToSubMenu(MenuItem i_AddToExistingMenu, MenuItem i_MenuItemToAdd)
        {
            if (m_AllMeunItems[i_AddToExistingMenu] == null)
            {
                m_AllMeunItems[i_AddToExistingMenu] = new List<MenuItem>();
                m_AllMeunItems[i_AddToExistingMenu].Add(new MenuItem("Back"));
            }

            m_AllMeunItems[i_AddToExistingMenu].Add(i_MenuItemToAdd);
            m_AllMeunItems.Add(i_MenuItemToAdd, null);
        }

        private void dealCurrentMenu(out bool o_Exit)
        {
            o_Exit = false;
            int choise = 0;

            printCurrentMenu(out int meunCounter);
            choise = getUserChoise(meunCounter);
            dealChoice(out o_Exit, choise);
        }

        private void printCurrentMenu(out int o_MeunCounter)
        {
            o_MeunCounter = 0;
            int lvl = m_MenuListItemsStack.Count;
            Level = lvl.ToString();
            Console.Clear();
            Console.WriteLine(Level);
            Console.WriteLine(m_Title);
            Console.WriteLine("Please Choose One of the Following");
            foreach (MenuItem menuItem in m_MenuItems)
            {
                Console.WriteLine(o_MeunCounter.ToString() + ". " + menuItem.Title);
                o_MeunCounter++;
            }
        }

        private int getUserChoise(int i_MenuCounter)
        {
            string userChoise;
            int parseRes = 0;
            bool isParseComplete = false;
            bool isInRange = true;

            while (!isParseComplete)
            {
                userChoise = Console.ReadLine();
                isParseComplete = int.TryParse(userChoise, out parseRes);

                if (!isParseComplete)
                {
                    Console.WriteLine("Wrong Choice Please Choose One of the Following");
                }
                else
                {
                    isInRange = (parseRes >= 0) && (parseRes <= i_MenuCounter - 1);
                    if (!isInRange)
                    {
                        Console.WriteLine("Wrong Choice Please Choose One of the Following");
                        isParseComplete = false;
                    }
                }
            }

            return parseRes;
        }

        private void dealChoice(out bool o_Exit, int i_Choise)
        {
            o_Exit = false;

            if (m_MenuItems[i_Choise].Title == "Exit")
            {
                o_Exit = true;
            }
            else if (m_MenuItems[i_Choise].Title == "Back")
            {
                goToPriviesMenu();
            }
            else
            {
                if (isMethod(i_Choise))
                {
                    Console.Clear();
                    m_MenuItems[i_Choise].Clicked();
                }
                else
                {
                    goToNextMenu(i_Choise);
                }
            }
        }

        private void goToNextMenu(int choise)
        {
            m_MenuListItemsStack.Push(m_MenuItems);
            m_MenuTitleStack.Push(m_Title);
            m_Title = m_MenuItems[choise].Title;
            m_MenuItems = m_AllMeunItems[m_MenuItems[choise]];
        }

        private bool isMethod(int choise)
        {
            return m_AllMeunItems[m_MenuItems[choise]] == null;
        }

        private void goToPriviesMenu()
        {
            m_MenuItems = m_MenuListItemsStack.Pop();
            m_Title = m_MenuTitleStack.Pop();
        }
    }
}
