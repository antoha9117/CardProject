using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;
using UnityEditor;

public class LoadCards : MonoBehaviour {
    public string json_file;//название json файла
    public string waytospritesfolden;// путь к файлу с спрайтами
    public string wayandnameofallcardasset;// путь и название ассета в который всё сохраняем
    public cards.GeneralCardCollection allcards;
    //public List<cards.CardData> value;
    //public Sprite sp;

    // Use this for initialization
    void Start()
    {
        string way = Application.streamingAssetsPath + "/" + json_file;
        string readedLines = File.ReadAllText(way);
        allcards = new cards.GeneralCardCollection(readedLines, waytospritesfolden);
        Debug.Log(JsonUtility.ToJson(allcards));
        AssetDatabase.CreateAsset(allcards, wayandnameofallcardasset + ".asset");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
