using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/TileState")]
public class IntrinsicTileState : ScriptableObject
{
    public Sprite sprite;
    public bool walkable;
}
