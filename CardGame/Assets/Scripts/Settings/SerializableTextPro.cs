using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace CardGame.Settings
{
    [Serializable]
    public class SerializableTextPro : ISerializableElem<TextMeshPro>
    {
        public float fontSize;
        public FontStyles fontStyles;
        public TextAlignmentOptions alignment;
        public TMP_FontAsset font;
        public Vector4 margin;
        public int sortingOrder;
        public Vector2 size;
        public Vector3 localPosition;
        public bool autoSizing;
        public Color color;

        readonly float _fontSizeMin = 1;
        readonly float _fontSizeMax = 200;
        
        public SerializableTextPro()
        {
            fontSize = 12;
            fontStyles = FontStyles.Normal;
            alignment = TextAlignmentOptions.Center;
            font = null;
            margin = Vector4.zero;
            sortingOrder = 3;
            size = new Vector2(1, 1);
            localPosition = Vector3.zero;
            autoSizing = false;
            color = Color.white;
        }

        public TextMeshPro element
        {
            set
            {
                fontSize = value.fontSize;
                fontStyles = value.fontStyle;
                alignment = value.alignment;
                font = value.font;
                margin = value.margin;
                sortingOrder = value.sortingOrder;
                size = value.rectTransform.sizeDelta;
                localPosition = value.rectTransform.localPosition;
                autoSizing = value.enableAutoSizing;
                color = value.color;
            }
        }

        public TextMeshPro getElement(TextMeshPro elem)
        {
            elem.color = color;
            elem.fontSize = fontSize;
            elem.fontStyle = fontStyles;
            elem.alignment = alignment;
            if(font!=null)
                elem.font = font;
            elem.margin = margin;
            elem.sortingOrder = sortingOrder;
            elem.rectTransform.sizeDelta = size;
            elem.rectTransform.localPosition = localPosition;
            elem.enableAutoSizing = autoSizing;
            if(autoSizing)
            {
                elem.fontSizeMin = _fontSizeMin;
                elem.fontSizeMax = _fontSizeMax;
            }
            return elem;
        }
    }
}
