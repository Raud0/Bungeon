using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private IntrinsicTileState _tileState;
    public void CreateTile(IntrinsicTileState tileState)
    {
        _tileState = tileState;

        if (_tileState.walkable)
        {
            gameObject.AddComponent<Collider2D>();
        }
        
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = _tileState.sprite;
    }

    public bool IsWalkable()
    {
        return _tileState.walkable;
    }
}
