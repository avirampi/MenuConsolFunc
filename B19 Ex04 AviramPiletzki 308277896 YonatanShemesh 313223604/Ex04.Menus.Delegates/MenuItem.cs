using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void ClickEventHandler();

    public class MenuItem
    {
        private string m_Title;

        public event ClickEventHandler ClickOccured;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public void Clicked()
        {
            OnClick();
        }

        private void OnClick()
        {
            if (ClickOccured != null)
            {
                ClickOccured.Invoke();
            }
        }
    }
}
