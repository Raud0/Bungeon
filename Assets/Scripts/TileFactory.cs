using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    public GameObject CreateTile(IntrinsicTileState tileState, Vector2Int vector)
    {
        GameObject go = new GameObject();
        go.AddComponent<Tile>();
        go.AddComponent<SpriteRenderer>();
        go.transform.position = new Vector3(vector.x, vector.y, 0);
        
        return go;
    }
}
