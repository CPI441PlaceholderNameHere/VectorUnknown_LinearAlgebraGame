using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GenerateGrid : MonoBehaviour {

    public int rows = 20;
    public int columns;

    public int tileSize = 1;
    public float offset = 0.5f;

    public int quadrantSize = 10;

    public float gridHeight = 0.1f;

    public char[,] tileMapped;
    public GameObject[,] tileGrid;

    public GameObject tile;

    public Transform gridHolder;

    public TextAsset textInput;

    public Camera mainCamera;

	// Use this for initialization
	void Start () {
        columns = rows;
        offset = tileSize / 2;
        quadrantSize = rows / 2;

        tileMapped = new char[rows, columns];
        ReadTextLevels();
        InitializeGrid();


        //mainCamera.transform.position = new Vector3(rows/2,rows,columns/2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeGrid()
    {
        gridHolder = new GameObject("grid").transform;

        offset = (float)tileSize;
        offset = offset / 2;

        // first quadrant
        for (int i = quadrantSize; i < rows; i++)
        {
            for (int j = quadrantSize; j < columns; j++)
            { 
                GameObject instance = Instantiate(tile, 
                    new Vector3(i-quadrantSize, gridHeight, j-quadrantSize), Quaternion.identity) as GameObject;

                instance.transform.Translate(new Vector3(offset, 0.0f, offset));

                instance.transform.SetParent(gridHolder);

                TileMouseOver tileData = instance.GetComponent<TileMouseOver>();
                char type = tileMapped[i, j];

                tileData.tileType = type;

                // setting tile colors
                if (tileData.tileType == '0')
                {
                    tileData.baseColor = Color.black;
                }
                else if (tileData.tileType == 't')
                {
                    tileData.baseColor = Color.gray;
                }
                else if (tileData.tileType == 'g')
                {
                    tileData.baseColor = Color.green;
                }

            }
        }

        // second quadrant
        for (int i = 0; i < quadrantSize; i++)
        {
            for (int j = quadrantSize; j < columns; j++)
            {
                GameObject instance = Instantiate(tile,
                    new Vector3(i - quadrantSize, gridHeight, j - quadrantSize), Quaternion.identity) as GameObject;

                instance.transform.Translate(new Vector3(offset, 0.0f, offset));

                instance.transform.SetParent(gridHolder);

                TileMouseOver tileData = instance.GetComponent<TileMouseOver>();
                char type = tileMapped[i, j];

                tileData.tileType = type;

                // setting tile colors
                if (tileData.tileType == '0')
                {
                    tileData.baseColor = Color.black;
                }
                else if (tileData.tileType == 't')
                {
                    tileData.baseColor = Color.gray;
                }
                else if (tileData.tileType == 'g')
                {
                    tileData.baseColor = Color.green;
                }

            }
        }

        // third quadrant
        for (int i = 0; i < quadrantSize; i++)
        {
            for (int j = 0; j < quadrantSize; j++)
            {
                GameObject instance = Instantiate(tile,
                    new Vector3(i - quadrantSize, gridHeight, j - quadrantSize), Quaternion.identity) as GameObject;

                instance.transform.Translate(new Vector3(offset, 0.0f, offset));

                instance.transform.SetParent(gridHolder);

                TileMouseOver tileData = instance.GetComponent<TileMouseOver>();
                char type = tileMapped[i, j];

                tileData.tileType = type;

                // setting tile colors
                if (tileData.tileType == '0')
                {
                    tileData.baseColor = Color.black;
                }
                else if (tileData.tileType == 't')
                {
                    tileData.baseColor = Color.gray;
                }
                else if (tileData.tileType == 'g')
                {
                    tileData.baseColor = Color.green;
                }

            }
        }

        // fourth quadrant
        for (int i = quadrantSize; i < rows; i++)
        {
            for (int j = 0; j < quadrantSize; j++)
            {
                GameObject instance = Instantiate(tile,
                    new Vector3(i - quadrantSize, gridHeight, j - quadrantSize), Quaternion.identity) as GameObject;

                instance.transform.Translate(new Vector3(offset, 0.0f, offset));

                instance.transform.SetParent(gridHolder);

                TileMouseOver tileData = instance.GetComponent<TileMouseOver>();
                char type = tileMapped[i, j];

                tileData.tileType = type;

                // setting tile colors
                if (tileData.tileType == '0')
                {
                    tileData.baseColor = Color.black;
                }
                else if (tileData.tileType == 't')
                {
                    tileData.baseColor = Color.gray;
                }
                else if (tileData.tileType == 'g')
                {
                    tileData.baseColor = Color.green;
                }

            }
        }
    }

    void ReadTextLevels()
    {
        string text = textInput.text;

        // remove newlines and returns

        for (int i = text.Length-1; i >= 0; i--)
        {
            if (text[i] == '\n' || text[i] == '\r')
            {
                string newText = text.Remove(i, 1);
                text = newText;
            }
            
        }

        // convert text into 2D array
        // must be correct size

        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                tileMapped[i, j] = text[index];
                index++;
            }
        }

        Debug.Log(tileMapped.ToString());
    }
}
