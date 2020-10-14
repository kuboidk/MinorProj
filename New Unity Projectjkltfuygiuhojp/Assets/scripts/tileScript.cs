using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class tileScript : MonoBehaviour
{
    public Vector3Int tileSize;
    public Tilemap tilemap;
    public Tile tileSprite1;
    public Tile tileSprite2;
    int width;
    int hight;
    // Update is called once per frame
    void Update()
    {
        width = tileSize.x;
        hight = tileSize.y;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < hight; j++)
            {
                tilemap.SetTile(new Vector3Int(-i +width / 2, -j+ hight / 2, 0), tileSprite1);
                
            }
        }

    }
}
    
