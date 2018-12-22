using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardGame.Settings
{
    [Serializable]
    public class SerializableTransform : ISerializableElem<Transform>
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public SerializableTransform()
        {
            position = Vector3.zero;
            rotation = Quaternion.Euler(0, 0, 0);
            scale = Vector3.one;
        }

        public Transform element
        {
            set
            {
                position = value.localPosition;
                rotation = value.localRotation;
                scale = value.localScale;
            }
        }

        public Transform getElement(Transform elem)
        {
            if(position!=null)
                elem.localPosition = position;
            if(rotation!=null)
                elem.localRotation = rotation;
            if(scale!=null)
                elem.localScale = scale;
            return elem;
        }
    }
}
