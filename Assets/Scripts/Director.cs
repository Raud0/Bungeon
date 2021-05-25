using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Director
{
    public abstract Chunk Construct(IBuilder builder);
}
