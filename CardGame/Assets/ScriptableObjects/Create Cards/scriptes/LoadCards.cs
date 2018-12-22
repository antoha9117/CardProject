using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;
using UnityEditor;

public class LoadCards : MonoBehaviour {

    public ScriptableObject m;
    public string way_to_txt_file;//Путь к файлу с текстовым файлом
    public string way_to_sprites;//Куда будем сохранять спрайты
    public string way_to_scriptableobject;//Куда будем сохранять scriptableobject

    string[] masck;
    ScriptableObjectCard asset;

    public string[] readOneCard(string allLines, ref int type_err)
    {
        string[] answer = new string[masck.Length];


        for (int j = 0; j < masck.Length; j++)
        {
            Regex reg_masc = new Regex(@"\s*""" + masck[j] + @"""\s?:\s*([^,\s]+(\s[^,\s]+)*)\s*,\s*");
            Match sofpadenija = reg_masc.Match(allLines);
            if (sofpadenija.Success)
            {
                answer[j] = sofpadenija.Groups[1].Value;
            }
            else
            {
                answer[j] = "";
            }
        }

        return answer;
    }

    public string[][] readAllCard(string allLines, ref int number_card, ref int type_err)
    {
        string[] cards = allLines.Split('}');
        int N = cards.Length - 1;

        string[][] jaggedArray = new string[N][];
        int type = -1;

        for (int i = 0; i < N; i++)
        {

            cards[i] += ",";

            jaggedArray[i] = readOneCard(cards[i], ref type);
            if (type >= 0)
            {
                number_card = i;
                type_err = type;
            }

        }

        return jaggedArray;
    }



    public string LoadSprite(string way, string name)
    {
        Texture2D texture = null;
        byte[] fileData;

        if (File.Exists(way))
        {
            try
            {//возможно можно улучшить
                fileData = File.ReadAllBytes(way);
                texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);

                Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));

                string path = way_to_sprites + name + ".png";//TODO: форматы могут быть разные
                File.WriteAllBytes(path, sp.texture.EncodeToPNG());
                AssetDatabase.Refresh();

                AssetDatabase.ImportAsset(path);
                TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
                importer.textureType = TextureImporterType.Sprite;
                AssetDatabase.WriteImportSettingsIfDirty(path);

                AssetDatabase.Refresh();
                return path;
            }
            catch
            {
                return null;
            }
        }
        //Debug.Log("ERROR_IMAGE:  for  way "+way+" from ID "+ name+"\n");
        return null;
    }

    public string Load(string way)
    {
        string res = "";
        int number = -1;
        int type = 0;
        string readedLines = File.ReadAllText(way);
        readedLines = Regex.Replace(readedLines, @"\n+", " ");
        readedLines = Regex.Replace(readedLines, @"\s+", " ");

        string[][] ans = readAllCard(readedLines, ref number, ref type);// разбиваем всё на массив каждый элемент входные данные для элементов каждой карты строк 
        if (number >= 0)
        {
            res = "ERROR in LOAD: " + (number + 1).ToString() + " , in Type" + masck[type];
        }

        for (int i = 0; i < ans.Length; i++)//создаём ассеты
        {
            string asset_name = ans[i][0];// asset.nameID;// + ".asset";
            //"Assets/ScriptableObjects/Cards"
            int k = 1;
            bool t = false;
            while (AssetDatabase.FindAssets(asset_name, new[] { way_to_scriptableobject }).Length > 0)
            {
                asset_name = asset.nameID + "(" + k.ToString() + ")";
                k++;
                t = true;
            }
            if (t)
            {
                res += "Simullar nameID in card number " + (i + 1).ToString() + "\n";
            }

            string assetway = LoadSprite(ans[i][6], "sprite_" + asset_name);//создаём спрайты
            if (assetway == null)
                res += "ERRor in create SPrite  in card number " + (i + 1).ToString() + "\n";
            asset = new ScriptableObjectCard(ans[i], AssetDatabase.LoadAssetAtPath(assetway, typeof(Sprite)) as Sprite);
            asset.artwork = AssetDatabase.LoadAssetAtPath(assetway, typeof(Sprite)) as Sprite;

            AssetDatabase.CreateAsset(asset, way_to_scriptableobject + asset_name + ".asset");
        }
        return res;
    }


    // Use this for initialization
    void Start()
    {
        masck = new string[] { "nameID", "nameCard", "description", "attack", "heals", "manaCost", "artwork" };

        string result = Load(way_to_txt_file);// основная функция
        /*if (result == null || result == "")
        {
            Debug.Log("successful download");
        }
        else
        {
            Debug.LogError(result);
        }*/
    }

    // Update is called once per frame
    void Update () {
		
	}
}
