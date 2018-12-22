using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Scriptable;
using UnityEditor;
using Card.RenderCard.Facilities;
using System;

namespace Card.RenderCards
{
    public class CreatorCard : MonoBehaviour
    {
        public Sprite Attack;
        public Sprite Face;
        public Sprite Health;
        public Sprite Morale;
        public Sprite Price;
        public Sprite Shirt;
        public Sprite Art;

        public Material mat;

        public float Unit;

        //ScriptableSettingsRenderCard settings;
        bool isPlay;
        int order = 0;
        int cardNum = 0;

        private ScriptableSettingsImage s_shirt;
        private ScriptableSettingspCaptionImage s_attack;
        private ScriptableSettingsImage s_face;
        private ScriptableSettingspCaptionImage s_morale;
        private ScriptableSettingspCaptionImage s_health;
        private ScriptableSettingspCaptionImage s_price;

        CardRender curCard;

        void Awake()
        {
            s_shirt = CreateSO<ScriptableSettingsImage>("GraphicsCadr/Settings/s_shirt");
            s_attack = CreateSO<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_attack");
            s_face = CreateSO<ScriptableSettingsImage>("GraphicsCadr/Settings/s_face");
            s_morale = CreateSO<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_morale");
            s_health = CreateSO<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_health");
            s_price = CreateSO<ScriptableSettingspCaptionImage>("GraphicsCadr/Settings/s_price");
            Debug.Log("ScriptableObject extracted!");
        }

        void Start()
        {
            Load();
        }

        private GameObject CrElem(Sprite s, string name, Transform parent)
        {
            GameObject card = new GameObject(name);
            card.transform.parent = parent;
            SpriteRenderer sr = card.AddComponent<SpriteRenderer>();
            sr.sprite = s;
            sr.shadowCastingMode = ShadowCastingMode.On;
            sr.material = mat;
            sr.sortingOrder = order++;
            return card;
        }

        private GameObject CrTextPro(string name, Transform parent)
        {
            GameObject text = new GameObject(name);
            text.transform.parent = parent;
            TextMeshPro tx = text.AddComponent<TextMeshPro>();
            SortingGroup sort = text.AddComponent<SortingGroup>();
            sort.sortingOrder = order++;
            return text;           
        }

        public void ButtonSave()
        {
            Save();
        }

        public void ButtonLoad()
        {
            Load();
        }

        private void Load()
        {
            if (curCard != null)
                Destroy(curCard.cardObject.transformObj.gameObject);

            CardFacilitie facilitie = new SadowTwoSideCardFacilitie();
            curCard = facilitie.CreateMinionCard();
            curCard.Configure();
            Debug.Log("Card Built!");
        }

        private void Save()
        {
            s_shirt.transform.element = curCard.shift.transform;
            s_shirt.spriteRenderer.element = curCard.shift.spriteRenderer;
            //s_shirt.spriteRenderer.material = (Material)AssetDatabase.LoadAssetAtPath("Assets/Graphics/Materials/SpShadow.mat", typeof(Material)); 

            s_face.transform.element = curCard.face.transform;
            s_face.spriteRenderer.element = curCard.face.spriteRenderer;

            s_attack.spriteRenderer.element = curCard.attack.spriteRenderer;
            s_attack.transform.element = curCard.attack.transform;
            s_attack.text.element = curCard.attack.textMesh;

            s_morale.spriteRenderer.element = curCard.morale.spriteRenderer;
            s_morale.transform.element = curCard.morale.transform;
            s_morale.text.element = curCard.morale.textMesh;

            s_health.spriteRenderer.element = curCard.health.spriteRenderer;
            s_health.transform.element = curCard.health.transform;
            s_health.text.element = curCard.health.textMesh;

            s_price.spriteRenderer.element = curCard.price.spriteRenderer;
            s_price.transform.element = curCard.price.transform;
            s_price.text.element = curCard.price.textMesh;

            AssetDatabase.Refresh();
            EditorUtility.SetDirty(s_shirt);
            EditorUtility.SetDirty(s_face);
            EditorUtility.SetDirty(s_attack);
            EditorUtility.SetDirty(s_morale);
            EditorUtility.SetDirty(s_health);
            EditorUtility.SetDirty(s_price);
            AssetDatabase.SaveAssets();
            Debug.Log("Save Complete!");
        }

        private T CreateSO<T>(string path) where T : ScriptableObject
        {
            T settings = Resources.Load<T>(path);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(settings, "Assets/Resources/" + path + ".asset");
                AssetDatabase.SaveAssets();
            }
            return settings;
        }
    }
}