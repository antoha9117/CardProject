using Scriptable;
using UnityEngine;
using TMPro;
using System;

namespace Card.RenderCard.Parts
{
    class SpriteImageRender : ImageRender
    {
        public SpriteImageRender(ScriptableSettingsImage settings, Transform parnt, Material material, string name = "ImageRender")
        {
            if (settings != null)
            {
                GameObject image = new GameObject(name);
                image.transform.parent = parnt;
                transform = image.transform;
                settings.transform.getElement(image.transform);

                spriteRenderer = image.AddComponent<SpriteRenderer>();
                spriteRenderer = settings.spriteRenderer.getElement(spriteRenderer);
                spriteRenderer.material = material;
            }
        }
    }
}
