using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public bool Walk(Vector3 direction)
    {
        if (!IsPositionWalkable(transform.position + direction))
            return false;

        return Move(direction);
    }

    private bool IsPositionWalkable(Vector3 pos)
    {
        return !Physics2D.OverlapPoint(pos);
    }

    private bool Move(Vector3 direction)
    {
        Vector3 from = transform.position;
        Vector3 to = from + direction;
        transform.position = to;

        return true;
    }    
}
