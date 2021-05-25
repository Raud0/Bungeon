using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelDirector : Director
{
    public override void Construct(ChunkBuilder builder)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (x == 5 || y == 5)
                {
                    builder.BuildFloor(x, y);
                }
                else
                {
                    builder.BuildWall(x, y);
                }
            }
        }
    }
}
