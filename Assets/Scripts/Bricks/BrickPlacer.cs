using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    public int yOffset = 20;

    public GameObject BrickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
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

                switch ( UnityEngine.Random.Range(0,2))
                {
                    case 0:
                        brickBuilder = new MidBrick(blockPrefab, canvas, scoreTuple );
                        break;
                    case 1:
                        brickBuilder = new MidBrick(blockPrefab, canvas, scoreTuple);
                        break;
                    default:
                        brickBuilder = new WeakBrick(blockPrefab, canvas);
                        break;

                }
                brickBuilder.SetHealth();
                brickBuilder.SetPosition(blockWidth, blockHeight, position);


                //GameObject block = Instantiate(blockPrefab, canvas);


                //RectTransform blockRect = block.GetComponent<RectTransform>();



                //blockRect.anchoredPosition = position;
                //blockRect.sizeDelta = new Vector2(blockWidth, blockHeight);
            }
        }
    }
}
