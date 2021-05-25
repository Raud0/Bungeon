using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Person _activePerson;
    private List<Person> _persons;
    
    public static event Action personMoved;

}
