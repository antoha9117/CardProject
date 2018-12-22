using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Settings
{
    interface ISerializableElem<T>
    {
        T element { set; }
        T getElement(T elem);
    }
}
