using UnityEngine;

using Card.StateCard;
using Card.Data;

namespace CardGame.Elements
{
    abstract class Card : MonoBehaviour
    {
        StateCardContext State = new StateCardContext(new WateState());
        CardData Data;
        CardData DataTamp;

    }
}
