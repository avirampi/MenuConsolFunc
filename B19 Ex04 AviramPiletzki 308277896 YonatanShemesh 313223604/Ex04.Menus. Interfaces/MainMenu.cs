using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private string m_Title = null;
        private string m_MenuLevel = null;
        private List<IMenuItems> m_MenuItems = null;
        private Stack<List<IMenuItems>> m_MenuListItemsStack;
        private Stack<string> m_MenuTitleStack;
        private Dictionary<IMenuItems, List<IMenuItems>> m_AllMeunItems;

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_MenuListItemsStack = new Stack<List<IMenuItems>>();
            m_MenuTitleStack = new Stack<string>();
            m_AllMeunItems = new Dictionary<IMenuItems, List<IMenuItems>>();
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
            foreach (IMenuItems menuItem in m_MenuItems)
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
                m_MenuItems = m_MenuListItemsStack.Pop();
                m_Title = m_MenuTitleStack.Pop();
            }
            else
            {
                if (m_AllMeunItems[m_MenuItems[i_Choise]] == null)
                {
                    Console.Clear();
                    m_MenuItems[i_Choise].OnClick();
                }
                else
                {
                    m_MenuListItemsStack.Push(m_MenuItems);
                    m_MenuTitleStack.Push(m_Title);
                    m_Title = m_MenuItems[i_Choise].Title;
                    m_MenuItems = m_AllMeunItems[m_MenuItems[i_Choise]];
                }
            }
        }

        public void AddToMenu(IMenuItems i_MenuItem)
        {
            ////There are no Items At The Menu
            if (m_MenuItems == null)
            {
                m_MenuItems = new List<IMenuItems>();
                m_MenuItems.Add(new ReturnButtom("Exit"));
            }

            m_MenuItems.Add(i_MenuItem);
            m_AllMeunItems.Add(i_MenuItem, null);
        }

        public void AddToSubMenu(IMenuItems i_AddToExistingMenu, IMenuItems i_MenuItemToAdd)
        {
            if (m_AllMeunItems[i_AddToExistingMenu] == null)
            {
                m_AllMeunItems[i_AddToExistingMenu] = new List<IMenuItems>();
                m_AllMeunItems[i_AddToExistingMenu].Add(new ReturnButtom("Back"));
            }

            m_AllMeunItems[i_AddToExistingMenu].Add(i_MenuItemToAdd);
            m_AllMeunItems.Add(i_MenuItemToAdd, null);
        }
    }
}
