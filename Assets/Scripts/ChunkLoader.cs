using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkLoader : MonoBehaviour
{
    private Director _roomDirector;
    private Director _tunnelDirector;
    private Dictionary<Vector2Int, Chunk> _chunks;
    private Vector2Int centralCoords;

    private void Awake()
    {
        _roomDirector = new RoomDirector();
        _tunnelDirector = new TunnelDirector();
        _chunks = new Dictionary<Vector2Int, Chunk>();

        centralCoords = new Vector2Int(-999999999, -999999999);
        
        Events.PersonMoved += OnPersonMoved;
        Events.PersonSelected += OnPersonSelected;
    }

    private Vector2Int CoordsOfPosition(Vector3 position)
    {
        float x = position.x;
        float y = position.y;

        int ix = Mathf.FloorToInt(x / 10f);
        int iy = Mathf.FloorToInt(y / 10f);
        
        return new Vector2Int(ix, iy);
    }

    private Chunk ConstructChunk(Vector2Int coords)
    {
        Director director = null;
        switch (Random.Range(0,2))
        {
            case 0: director = _roomDirector; break;
            case 1: director = _tunnelDirector; break;
            default: director = _roomDirector; break;
        }

        director.Construct(ChunkBuilder.Instance);
        Chunk chunk = ChunkBuilder.Instance.GetResult();
        
        var transform1 = chunk.transform;
        transform1.parent = transform;
        transform1.localPosition = new Vector3(coords.x*10, coords.y*10, -1);

        return chunk;
    }
    
    private void DoLoading(Vector2Int coords, int range)
    {
        for (int x = -range; x <= range; x++)
        {
            for (int y = -range; y <= range; y++)
            {
                Vector2Int coordsPointer = coords + new Vector2Int(x, y);
                if (!_chunks.ContainsKey(coordsPointer))
                {
                    _chunks.Add(coordsPointer, ConstructChunk(coordsPointer));
                }
                _chunks[coordsPointer].Load();
            }
        }
    }

    private void DoUnLoading(Vector2Int coords, int range)
    {
        for (int x = -range - 1; x <= range + 1; x++)
        {
            for (int y = -range - 1; y <= range + 1; y++)
            {
                if (y >= -range && y <= range && x >= -range && x <= range) continue;

                Vector2Int coordsPointer = coords + new Vector2Int(x, y);
                if (_chunks.ContainsKey(coordsPointer))
                {
                    _chunks[coordsPointer].Unload();
                }
            }
        }
    }
    
    public void OnPersonMoved(Vector3 position)
    {
        Vector2Int coords = CoordsOfPosition(position);
        
        
        if (centralCoords.Equals(coords)) return;
        
        centralCoords = coords;
        DoUnLoading(coords, 1);
        DoLoading(coords, 1);
    }
    
    private void OnPersonSelected(Person person)
    {
        Vector2Int coords = CoordsOfPosition(person.transform.position);
        if (centralCoords.Equals(coords) ) return;
        
        centralCoords = coords;
        DoLoading(coords, 1);
    }
}
