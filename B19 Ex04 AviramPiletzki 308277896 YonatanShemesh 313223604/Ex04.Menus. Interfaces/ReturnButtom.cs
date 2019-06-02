using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ReturnButtom : IMenuItems
    {
        private string m_Title;

        public ReturnButtom(string i_Title)
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
            throw new NotImplementedException();
        }
    }
}
