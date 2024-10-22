
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveManager : MonoBehaviour
{

    public BrickPlacer brickPlacer;

    public int playerData = 5;

    private void Start()
    {
        if (MatchManager.instance.loadBricks)
        {
            Load();
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }

    }
    public void Save(int saveFile = 1)
    {
        List<BrickData> a = brickPlacer.SaveBricks();

        //string saved = "";

        //foreach (BrickData brick in a)
        //{
            
        //    saved += '\n'  + JsonUtility.ToJson(brick);
        //}

        BrickDataCollection bricks = new BrickDataCollection();
        bricks.brick = brickPlacer.SaveBricks();

        var saved = JsonUtility.ToJson(bricks);

        //var saved = JsonUtility.ToJson(brickPlacer.SaveBricks());
        Debug.Log(saved);

        //                            saveFile path                                            Pass the json String
        File.WriteAllText(Application.dataPath + "/saveFile" + saveFile.ToString() + ".json", saved);

        Debug.Log(Application.dataPath);


        SceneManager.LoadScene(1);
    }

    public void Load(int saveFile = 1)
    {
        var path = Application.dataPath + "/saveFile" + saveFile.ToString() + ".json";

        BrickDataCollection bricks = new BrickDataCollection();

        if (File.Exists(path))
        {

            string fileContent = File.ReadAllText(path);
            

            Debug.Log(fileContent);

            JsonUtility.FromJsonOverwrite(fileContent, bricks);

            brickPlacer.LoadBricks(bricks);



        }
    }

    public void SaveBinary()
    {
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/playerData1.json", FileMode.Create);

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        binaryFormatter.Serialize(fileStream, playerData);

        fileStream.Close();

    }


    public void LoadBinary()
    {
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/playerData1.json", FileMode.Open);




    }



}


[System.Serializable]
public class BrickDataCollection
{
    public List<BrickData> brick;
}