using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilder : IBuilder
{
    private Chunk _chunk;
    public IntrinsicTileState WallState;
    public IntrinsicTileState FloorState;
    
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
        return _chunk;
    }
}
