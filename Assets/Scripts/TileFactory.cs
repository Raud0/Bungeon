using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    private static TileFactory _instance;
    public static TileFactory Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    public GameObject CreateTile(IntrinsicTileState tileState)
    {
        GameObject go = new GameObject();
        Tile tile = go.AddComponent<Tile>();
        tile.CreateTile(tileState);
        
        return go;
    }
}
