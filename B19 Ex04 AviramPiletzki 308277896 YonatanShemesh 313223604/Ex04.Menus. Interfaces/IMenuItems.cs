using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuItems
    {
        string Title
        {
            get;
            set;
        }

        void OnClick();
    }
}
