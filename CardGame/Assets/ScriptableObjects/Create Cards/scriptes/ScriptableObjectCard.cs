using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;
using UnityEditor;
using System.Linq;


namespace cards
{
    [System.Serializable]
    public class GeneralCardCollection : ScriptableObject
    {
        public List<CardData> value;  // CardData:{ nameID:string, manaCost:int, и тд. }

        public void setlen(int N = 0)
        {
            this.value = new List<CardData>();
            for (int i = 0; i < N; i++)
                this.value.Add(new CardData());
        }

        public GeneralCardCollection(string json, string waytosprite = "")
        {
            string[] cards = json.Split('}');
            int N = cards.Length - 2;
            this.setlen(N);// находим количество карт
            JsonUtility.FromJsonOverwrite(json, this); //Загружаем list из файла json
            for (int i = 0; i < N; i++)
            {
                this.value[i].LoadSprite(waytosprite);//Загружаем спрайты из resurses
            }
        }

        public GeneralCardCollection(int N)
        {
            this.setlen(N);
        }
    }

    [System.Serializable]
    public class CardData
    {
        public string nameID;
        public string nameCard;
        public string description;
        public int attack;
        public int heals;
        public int manaCost;
        public string artwork_name;
        public Sprite artwork;

        public CardData(string inNameID = "-1", string inNameCard = "default name", string inDescription = "", int inAttack = 0, int inHeals = 1, int inManacost = 100, string inAtwork_name = "default", Sprite inAtwork = null)
        {
            this.nameID = inNameID;
            this.nameCard = inNameCard;
            this.description = inDescription;
            this.attack = inAttack;
            this.heals = inHeals;
            this.manaCost = inManacost;
            this.artwork_name = inAtwork_name;
            this.artwork = inAtwork;
        }

        public Sprite LoadSprite(string waytosprite)
        {
            string nameSprite = "";
            if (waytosprite == "" || waytosprite == null)
                nameSprite = this.artwork_name;
            else
                nameSprite = waytosprite + "/" + this.artwork_name;
            if (Resources.Load<Sprite>(nameSprite) == null)//Проверяем что это не спрайт
            {
                string path = AssetDatabase.GetAssetPath(Resources.Load(nameSprite));// Здесь не совсем по феншую
                //Debug.Log(path);
                AssetDatabase.ImportAsset(path);
                TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;// делаем из картинки-ассета спрайт
                importer.textureType = TextureImporterType.Sprite;
                AssetDatabase.WriteImportSettingsIfDirty(path);
                AssetDatabase.Refresh();
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! reload sprite " + path);
            }

            this.artwork = Resources.Load<Sprite>(nameSprite);

            return this.artwork;
        }
    }
}
