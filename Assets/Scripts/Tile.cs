using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private IntrinsicTileState _tileState;
    public Tile(IntrinsicTileState tileState)
    {
        _tileState = tileState;
        if (tileState.walkable)
        {
            gameObject.AddComponent<Collider2D>();
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = tileState.sprite;

    }
}
