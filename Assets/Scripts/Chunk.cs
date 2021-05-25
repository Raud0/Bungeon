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
        if (_isLoaded) return;
        foreach(KeyValuePair<Vector2Int, IntrinsicTileState> entry in _tileStates)
        {
            GameObject tile = TileFactory.Instance.CreateTile(entry.Value);
            tile.transform.parent = transform;
            tile.transform.localPosition = new Vector3(entry.Key.x, entry.Key.y, 0);
        }
    }

    public void Unload()
    {
        if (!_isLoaded) return;
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

    public void AddTile(Vector2Int key, IntrinsicTileState state)
    {
        _tileStates.Add(key, state);
    }
}
