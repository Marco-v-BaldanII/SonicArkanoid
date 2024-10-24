
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

        MatchManager.instance.looseSignal += SaveHighScore;
        MatchManager.instance.looseSignal += DeleteSaveFile;

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

        SaveData data = new SaveData();
        data.bricks = brickPlacer.SaveBricks();
        data.points = MatchManager.instance.GetPoints();
        var saved = JsonUtility.ToJson(data);

        //                            saveFile path                                   Pass the json String
        File.WriteAllText(Application.dataPath + "/saveFile" + saveFile.ToString() + ".json", saved);
        SceneManager.LoadScene(1);


    }

    public void DeleteSaveFile()
    {
        File.Delete(Application.dataPath + "/saveFile1.json");
    }

    public bool SaveExists()
    {
        if (File.Exists(Application.dataPath + "/saveFile1.json"))
        {
            return true;
        }
        return false;
    }

    public void Load(int saveFile = 1)
    {
        var path = Application.dataPath + "/saveFile" + saveFile.ToString() + ".json";

        // create the save data class
        SaveData bricks = new SaveData();

        if (File.Exists(path))
        {

            string fileContent = File.ReadAllText(path);
            Debug.Log(fileContent);


            //save the filecontent into the "bricks" data structure
            JsonUtility.FromJsonOverwrite(fileContent, bricks);
            brickPlacer?.LoadBricks(bricks);
            MatchManager.instance.SavePoints(bricks.points);
            

        }
    }

    public int LoadHighScore()
    {
        var path = Application.dataPath + "/score.json";

        // create the save data class
        HighScore highScore = new HighScore(0);

        if (File.Exists(path))
        {

            string fileContent = File.ReadAllText(path);
            Debug.Log(fileContent);


            //save the filecontent into the "bricks" data structure
            JsonUtility.FromJsonOverwrite(fileContent, highScore);

            return highScore.highScore;
        }
        return -1; // no file exists
    }

    public void SaveHighScore()
    {
        int score = MatchManager.instance.GetPoints();

        if (score >= LoadHighScore())
        {
            HighScore highScore = new HighScore(score);
            var saved = JsonUtility.ToJson(highScore);
            File.WriteAllText(Application.dataPath + "/score.json", saved);

        }
    }

    private void OnDestroy()
    {
        MatchManager.instance.looseSignal -= SaveHighScore;
        MatchManager.instance.looseSignal -= DeleteSaveFile;
    }

}


[System.Serializable]
public class SaveData
{
    public List<BrickData> bricks;

    public int points;


}

public class HighScore
{
    public HighScore(int highScore)
    {
        this.highScore = highScore;
    }

    public int highScore;
}