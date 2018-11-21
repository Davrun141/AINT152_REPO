using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour {

    public Sprite[] tileSprites;
    public int worldWidthInTiles;
    public int worldHeightInTiles;
    public GameObject tilePrefab;

    private GameObject[,] tileArray;

    private GameObject tileReference;
    private float tileRowWidthStart;
    private float tileColumnHeightStart;

    private void Start()
    {
        //Set the start point of rows and collumns to the top left of the world
        tileRowWidthStart = (float)-1.6 * ((float)(worldWidthInTiles - 1) / 2);
        tileColumnHeightStart = (float)-1.6 * ((float)(worldHeightInTiles - 1) / 2);

        tileArray = new GameObject[worldWidthInTiles, worldHeightInTiles];
        for (int i = 0; i < worldHeightInTiles; i++)
        {
            for (int j = 0; j < worldWidthInTiles; j++)
            {
                tileArray[j, i] = TileCreation(1, j, i);
            }
        }
    }

    private GameObject TileCreation(int spriteNumber, int j, int i)
    {
        tileReference = Instantiate(tilePrefab);
        tileReference.transform.position = new Vector3(tileRowWidthStart + (float)(j * 1.6), tileColumnHeightStart + (float)(i * 1.6), tileReference.transform.position.z);


        return tileReference;
    }
}
