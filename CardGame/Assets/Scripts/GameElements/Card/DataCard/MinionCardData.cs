using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "NewMinionCardData", menuName = "ScriptableObject/Card/Minion")]
    public class MinionCardData : CardData
    {
        public int attack;
        public int heals;
    }
}
