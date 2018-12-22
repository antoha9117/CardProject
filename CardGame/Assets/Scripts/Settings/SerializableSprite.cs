using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace CardGame.Settings
{
    [Serializable]
    public class SerializableSprite : ISerializableElem<SpriteRenderer>
    {
        public Sprite sprite;
        public Material material;
        public int sortingOrder;

        readonly ShadowCastingMode shadowCastingMode = ShadowCastingMode.On;

        public SerializableSprite()
        {
            sprite = null;
            material = null;
            sortingOrder = 0;
        }

        public SpriteRenderer element
        {
            set
            {
                sprite = value.sprite;
                //EditorUtility.GetAssetPath(value.material);
                //"Assets/Graphics/Materials/SpShadow.mat"
                /*string pathMat = AssetDatabase.GetAssetPath(value.material.GetInstanceID());
                Debug.Log("MAT ID = " + value.material.GetInstanceID());
                Debug.Log("MAT = " + value.material);*/
                //material = (Material)AssetDatabase.LoadAssetAtPath(pathMat, typeof(Material));
                sortingOrder = value.sortingOrder;
            }
        }

        public SpriteRenderer getElement(SpriteRenderer elem)
        {
            if(sprite!=null)
                elem.sprite = sprite;
            if(material!=null)
                elem.material = material;

            elem.sortingOrder = sortingOrder;
            elem.shadowCastingMode = shadowCastingMode;
            return elem;
        }
    }
}
