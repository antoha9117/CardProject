using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class SelectCard : MonoBehaviour
    {
        public static SelectCard select;
        public Transform myTransform;
        public bool inHand = true;
        public int index;
        public CreateCard creator;
        public PutCard cell;

        void OnMouseDown()
        {
            select = this;
        }

        public void setTransf(Vector3 pos)
        {
            myTransform.position = pos;
        }
    }
}