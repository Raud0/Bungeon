using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private static Movement _instance;
    public static Movement Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    public GameObject _personPrefab;
    private Person _activePerson;
    private List<Person> _persons;

    private void Start()
    {
        _persons.Add(Instantiate(_personPrefab, new Vector3(0f, 0f, 1f), Quaternion.identity).GetComponent<Person>());
        _persons.Add(Instantiate(_personPrefab, new Vector3(0f, 50f, 1f), Quaternion.identity).GetComponent<Person>());

        _activePerson = _persons[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            Move(new Vector3(-1f,0f));
        }
        else if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            Move(new Vector3(1f,0f));
        }
        else if (Input.GetKeyDown(KeyCode.W)) //Up
        {
            Move(new Vector3(0f,1f));
        }
        else if (Input.GetKeyDown(KeyCode.S)) //Down
        {
            Move(new Vector3(0f,-1f));
        }
        else if (Input.GetKeyDown(KeyCode.Space)) //Change
        {
            ChangePerson();
        }
    }

    private void Move(Vector3 position)
    {
        if (_activePerson.Walk(position)) MovePerson(_activePerson.transform.position);
    }

    private void ChangePerson()
    {
        if (_persons.Count == 0) return;
        int i = _persons.IndexOf(_activePerson);
        Person _nextActive = _persons[(i + 1) % _persons.Count];
        if (_nextActive.Equals(_activePerson)) return;

        _activePerson = _nextActive;
        SelectPerson(_activePerson);
    }

    public static event Action<Vector3> personMoved;
    public static void MovePerson(Vector3 pos) => personMoved?.Invoke(pos);

    public static event Action<Person> personSelected;
    public static void SelectPerson(Person person) => personSelected?.Invoke(person);
}
