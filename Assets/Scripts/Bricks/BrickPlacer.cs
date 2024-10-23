using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class BrickPlacer : MonoBehaviour
{
    
    public GameObject blockPrefab; 
    public RectTransform canvas;  
    
    public int rows = 5;           
    public int columns = 5;        
    public float blockWidth = 50f; 
    public float blockHeight = 50f;
    public float spacing = 10f;

    public Score vScore;
    public Score hScore;

    public IBrick[,] brickMatrix;

    List<BrickData> list = new List<BrickData>();
    public List<Brick> bricks;

    public int yOffset = 20;

    public GameObject BrickPrefab;

    [SerializeField] private TextMeshProUGUI leveLabel;
    [SerializeField] private TextMeshProUGUI leveLabel2;

    // Start is called before the first frame update
    void Start()
    {
        leveLabel.text = "Level " + (MatchManager.instance.GetMatchesWon() % 2).ToString();
        leveLabel2.text = "Level " + (MatchManager.instance.GetMatchesWon() % 2).ToString();

        bricks = new List<Brick>();
        brickMatrix = new IBrick[rows, columns];
        if (MatchManager.instance.loadBricks == false)
        { 
            SpawnGrid(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceBricks()
    {
        //IBrick brickBuilder = new WeakBrick(BrickPrefab);

    }

    void SpawnGrid()
    {
        

        float gridWidth = columns * blockWidth + (columns - 1) * spacing;
        float gridHeight = rows * blockHeight + (rows - 1) * spacing;

   
        Vector2 startPosition = new Vector2( - gridWidth / 2f + blockWidth / 2f, gridHeight / 2f - blockHeight / 2f + yOffset);

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {

                /* Calculate the position for each block */
                Vector2 position = new Vector2(
                    startPosition.x + column * (blockWidth + spacing),
                    startPosition.y - row * (blockHeight + spacing)
                );

                IBrick brickBuilder;
                Tuple<Score, Score> scoreTuple = new Tuple<Score, Score>(vScore, hScore);

                var i = (MatchManager.instance.GetMatchesWon() % 2) + 2;
                int id = UnityEngine.Random.Range(0, i);


                // The more won matches the harder blocks spawn
                if (id == 0)
                {
                    brickBuilder = null;
                }
                else if (id < 2)
                {
                    brickBuilder = new WeakBrick(blockPrefab, canvas, scoreTuple, this); 
                }
                else
                {
                    brickBuilder = new MidBrick(blockPrefab, canvas, scoreTuple, this);
                }

                brickBuilder?.SetHealth();
                brickBuilder?.SetPosition(blockWidth, blockHeight, position);
            }
        }
    }

    public void LoadBricks(SaveData data)
    {


        foreach (BrickData Brickdata in data.bricks)
        {
            IBrick brickBuilder;
            Tuple<Score, Score> scoreTuple = new Tuple<Score, Score>(vScore, hScore);
            if (Brickdata.hp == 1)
            {
                brickBuilder = new WeakBrick(blockPrefab, canvas, scoreTuple, this);
            }
            else
            {
                brickBuilder = new MidBrick(blockPrefab, canvas, scoreTuple, this);
            }
            brickBuilder?.SetHealth();
            brickBuilder?.SetPosition(blockWidth, blockHeight, Brickdata.position);
            brickBuilder?.Load(Brickdata.position, Brickdata.hp);
        }
    }

    public List<BrickData> SaveBricks()
    {
        List<BrickData> brickData = new List<BrickData>();

        for (int i = 0; i < bricks.Count; ++i)
        {
          
            if (bricks[i] != null)
            {
                brickData.Add(bricks[i].GetSaveData());
            }
        }

        return brickData;

    }

}



[System.Serializable]
public class BrickData
{

    public BrickData(int hp, Vector2 position)
    {
        this.hp = hp;
        this.position = position;
    }

    public int hp;

    public Vector2 position;

}