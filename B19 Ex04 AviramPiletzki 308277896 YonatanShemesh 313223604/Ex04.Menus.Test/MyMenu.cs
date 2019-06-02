using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class MyMenu : Ex04.Menus.Delegates.MainMenu
    {
        private InterfaceImplement m_MyInterfaceMenu = new InterfaceImplement("Interface Menu");
        private DelegateImplement m_MyDelegateMenu = new DelegateImplement("Delegate Menu");

        public MyMenu(string title) : base(title)
        {
            MenuItem myInterfaceMenu = new MenuItem("Interface Menu");
            myInterfaceMenu.ClickOccured += new ClickEventHandler(m_MyInterfaceMenu.Show);
            MenuItem myDelegateMenu = new MenuItem("Delegate Menu");
            myDelegateMenu.ClickOccured += new ClickEventHandler(m_MyDelegateMenu.Show);

            AddToMenu(myInterfaceMenu);
            AddToMenu(myDelegateMenu);
        }
    }
}
