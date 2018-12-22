using Scriptable;
using UnityEngine;
using TMPro;

namespace Card.RenderCard.Parts
{
    class SpriteAttributeRender : AttributeRender
    {
        public SpriteAttributeRender(ScriptableSettingspCaptionImage settings, Transform parnt, Material material, string name = "AttributeRender")
        {
            if (settings != null)
            {
                GameObject attribute = new GameObject(name);
                attribute.transform.parent = parnt;
                transform = attribute.transform;
                settings.transform.getElement(attribute.transform);

                spriteRenderer = attribute.AddComponent<SpriteRenderer>();
                spriteRenderer = settings.spriteRenderer.getElement(spriteRenderer);
                spriteRenderer.material = material;

                GameObject textAttribute = new GameObject("Text");
                textAttribute.transform.parent = attribute.transform;
                textMesh = textAttribute.AddComponent<TextMeshPro>();
                textMesh = settings.text.getElement(textMesh);
            }
        }
    }
}
