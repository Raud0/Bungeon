using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Person _activePerson;
    private List<Person> _persons;
    
    public GameObject _personPrefab;

    private static Movement _instance;
    public static Movement Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
            _persons = new List<Person>();
        }

    }


    private void Start()
    {
        _persons.Add(Instantiate(_personPrefab, new Vector3(5f, 5f, 1f), Quaternion.identity).GetComponent<Person>());
        _persons.Add(Instantiate(_personPrefab, new Vector3(5f, 55f, 1f), Quaternion.identity).GetComponent<Person>());

        _activePerson = _persons[0];
        Move(new Vector3(transform.position.x, transform.position.y));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            Move(new Vector3(1f,0f));
        }
        else if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            Move(new Vector3(-1f,0f));
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
        if (_activePerson.Walk(position))
        {
            Events.MovePerson(_activePerson.transform.position);
            MoveCameraToPlayer();
        }
    }

    private void ChangePerson()
    {
        if (_persons.Count == 0) return;
        int i = _persons.IndexOf(_activePerson);
        Person _nextActive = _persons[(i + 1) % _persons.Count];
        if (_nextActive.Equals(_activePerson)) return;
        
        _activePerson = _nextActive;
        Events.SelectPerson(_activePerson);
        MoveCameraToPlayer();
    }


    private void MoveCameraToPlayer()
    {
        Vector3 cameraPos = new Vector3(_activePerson.transform.position.x, _activePerson.transform.position.y, 50);
        Camera.main.transform.position = cameraPos;
    }

}
