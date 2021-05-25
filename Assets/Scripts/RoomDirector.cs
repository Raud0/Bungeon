using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDirector : Director
{
    public override void Construct(IBuilder builder)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                builder.BuildFloor(x, y);
            }
        }
    }
}
