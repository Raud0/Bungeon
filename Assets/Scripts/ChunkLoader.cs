using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkLoader : MonoBehaviour
{
    private Director _roomDirector;
    private Director _tunnelDirector;
    private ChunkBuilder _builder;
    private Dictionary<Vector2Int, Chunk> _chunks;
    private Vector2Int centralCoords;

    private void Awake()
    {
        _builder = new ChunkBuilder();
        _roomDirector = new RoomDirector();
        _tunnelDirector = new TunnelDirector(); 

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

        director.Construct(_builder);
        Chunk chunk = _builder.GetResult();
        
        var transform1 = chunk.transform;
        transform1.parent = transform;
        transform1.localPosition = new Vector3(coords.x, coords.y, 0);

        return chunk;
    }
    
    private void DoLoading(Vector2Int coords, int range)
    {
        for (int x = -range; x <= range; x++)
        {
            for (int y = range; y <= range; y++)
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
            for (int y = range - 1; y <= range + 1; y++)
            {
                if (x >= range && x <= range) continue;
                if (y >= range && x <= range) continue;

                Vector2Int coordsPointer = coords + new Vector2Int(x, y);
                if (_chunks.ContainsKey(coordsPointer)) _chunks[coordsPointer].Unload();
            }
        }
    }
    
    public void OnPersonMoved(Vector3 position)
    {
        Vector2Int coords = CoordsOfPosition(position);
        if (centralCoords != null && centralCoords != coords) return;
        
        centralCoords = coords;
        DoUnLoading(coords, 1);
        DoLoading(coords, 1);
    }

    public void OnPersonSwitch(Vector3 position) {
        Vector2Int coords = CoordsOfPosition(position);
        DoLoading(coords, 1);
    }

    public void OnPersonSelected(Person person)
    {
        Vector2Int coords = CoordsOfPosition(person.transform.position);
        if (centralCoords != coords) return;
        
        centralCoords = coords;
        DoLoading(coords, 1);
    }
}
