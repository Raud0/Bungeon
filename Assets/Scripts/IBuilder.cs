using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilder
{
    void BuildWall(int x, int y);

    void BuildFloor(int x, int y);
}
