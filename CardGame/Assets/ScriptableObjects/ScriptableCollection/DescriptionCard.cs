using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "NewDescriptionsAbilities", menuName = "ScriptableObject/Collection/DescriptionsAbilities")]
    public class DescriptionAbilities : ScriptableObject
    {
        //описание способностей в игре
        public List<string> key;
        public List<string> value;
    }
}
