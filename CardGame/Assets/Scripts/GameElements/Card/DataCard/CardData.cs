using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card.Data
{
    public abstract class CardData     //Еще могу быть Здания, Оружие и др.
    {
        public string nameID;
        public string nameCard;
        public string description;
        public string type;
        public int manaCost;
        //TODO: Сюда добавляем общие для всех карт параметры
    }
}
