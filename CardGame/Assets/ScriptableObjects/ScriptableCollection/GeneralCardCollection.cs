using Card.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "NewGeneralCardCollection", menuName = "ScriptableObject/Collection/GeneralCardCollection")]
    public class GeneralCardCollection : ScriptableObject
    {
        public List<CardData> value;
    }
}