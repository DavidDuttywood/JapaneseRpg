using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Button interactButton;

    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    private void Awake()
    {
        instance = this;
        Load();
    }

    public void Save() {
        Vector3 playerPosition = player.transform.position;
        bool somethingElse = false;
        string[] contents = new string[]
        {
            ""+playerPosition.x,
            ""+playerPosition.y,
            ""+somethingElse
        };

        string saveString = string.Join(SAVE_SEPARATOR, contents);
        File.WriteAllText(Application.dataPath + "save.txt", saveString);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "save.txt");

            string[] contents = saveString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

            float posX = float.Parse(contents[0]);
            float posY = float.Parse(contents[1]);
            player.transform.position = new Vector3(posX, posY);
        }
    }


}
