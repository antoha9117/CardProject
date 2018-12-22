using Card.RenderCard.Parts;
using Scriptable;
using UnityEngine;

namespace Card.RenderCard.Factorys
{
    class SadowTwoSideCardFactory : CardFactory
    {
        private ScriptableSettingsImage s_shirt = Resources.Load<ScriptableSettingsImage>("GraphicsCadr/Settings/s_shirt");
        private ScriptableSettingspCaptionImage s_attack = Resources.Load<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_attack");
        private ScriptableSettingsImage s_face = Resources.Load<ScriptableSettingsImage>("GraphicsCadr/Settings/s_face");
        private ScriptableSettingspCaptionImage s_morale = Resources.Load<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_morale");
        private ScriptableSettingspCaptionImage s_health = Resources.Load<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_health");
        private ScriptableSettingspCaptionImage s_price = Resources.Load<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_price");

        private Material material = Resources.Load<Material>("GraphicsCadr/ShadowSprite");

        public override AttributeRender CreateAttack(Transform parent)
        {
            SpriteAttributeRender elem = new SpriteAttributeRender(s_attack, parent, material, "AttackRender");
            elem.spriteRenderer.material = material;
            return elem;
        }

        public override BaseObjectRender CreateBase(string name)
        {
            return new EmptyBaseObjectRender(name);
        }

        public override ImageRender CreateFace(Transform parent)
        {
            SpriteImageRender elem = new SpriteImageRender(s_face, parent, material, "FaceRender");
            return elem;
        }

        public override AttributeRender CreateHealth(Transform parent)
        {
            SpriteAttributeRender elem = new SpriteAttributeRender(s_health, parent, material, "HealthRender");
            return elem;
        }

        public override AttributeRender CreateMorale(Transform parent)
        {
            SpriteAttributeRender elem = new SpriteAttributeRender(s_morale, parent, material, "MoraleRender");
            return elem;
        }

        public override ImageRender CreateShirt(Transform parent)
        {
            SpriteImageRender elem = new SpriteImageRender(s_shirt, parent, material, "ShirtRender");
            return elem;
        }

        public override AttributeRender CretePrice(Transform parent)
        {
            SpriteAttributeRender elem = new SpriteAttributeRender(s_price, parent, material, "PriceRender");
            return elem;
        }
    }
}
