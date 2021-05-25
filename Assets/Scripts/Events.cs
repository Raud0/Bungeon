using System;
using UnityEngine;

public static class Events
{
    public static event Action<Vector3> PersonMoved;
    public static void MovePerson(Vector3 pos) => PersonMoved?.Invoke(pos);

    public static event Action<Person> PersonSelected;
    public static void SelectPerson(Person person) => PersonSelected?.Invoke(person);

}