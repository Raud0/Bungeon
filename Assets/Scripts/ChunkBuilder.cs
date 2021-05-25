using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilder : MonoBehaviour
{
    
    private static ChunkBuilder _instance;
    public static ChunkBuilder Instance { get { return _instance; } }


    
    private Chunk _chunk;
    public Chunk chunkPrefab;
    public IntrinsicTileState WallState;
    public IntrinsicTileState FloorState;

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
            _chunk = Instantiate(chunkPrefab);
        }
    }

    public void BuildWall(int x, int y)
    {
        _chunk.AddTile(new Vector2Int(x, y), WallState);
    }

    public void BuildFloor(int x, int y)
    {
        _chunk.AddTile(new Vector2Int(x, y), FloorState);
    }

    public Chunk GetResult()
    {
        Chunk toreturn = _chunk;
        _chunk = Instantiate(chunkPrefab, new Vector3(-1000, -1000, -1000), Quaternion.identity);
        return toreturn;
    }
}
