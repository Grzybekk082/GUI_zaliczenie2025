using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;


namespace GUI_zaliczenie2025.Classes
{
    internal abstract class PageCreator
    {
        internal abstract void Display(Stack<PageCreator> navigationStack);
    }
}
