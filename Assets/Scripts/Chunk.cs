using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private Dictionary<Vector2Int, IntrinsicTileState> _tileStates;
    private bool _isLoaded;

    private void Awake()
    {
        _isLoaded = false;
        _tileStates = new Dictionary<Vector2Int, IntrinsicTileState>();
    }

    public void Load()
    {
        if (!_isLoaded)
        {
            //Create children based on dict
        }
    }

    public void Unload()
    {
        if (_isLoaded)
        {
            // Destroy children
        }
    }

    public void AddTile(Vector2Int key, IntrinsicTileState state)
    {
        _tileStates.Add(key, state);
    }
}
