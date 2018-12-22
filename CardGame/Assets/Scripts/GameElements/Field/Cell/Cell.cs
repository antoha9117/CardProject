using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Cell.StateCell;

namespace CardGame.Elements
{
    abstract class Cell : MonoBehaviour
    {
        StateCellContext State = new StateCellContext(new EmptyState());
    }
}
