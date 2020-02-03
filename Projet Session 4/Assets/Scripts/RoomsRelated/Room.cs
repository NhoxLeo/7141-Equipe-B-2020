﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    #region Variables
    [Header("Access points")]
    [SerializeField] private GameObject[] Doors = null;

    [Header("Room Related")]
    [SerializeField] private List<GameObject> envrionmentObjects = new List<GameObject>();

    [SerializeField] private GameObject fog = null;
    private bool activeFog = true;

    #endregion

    #region Unity's Methods
    private void Update()
    {
        if (!TestDummyScript.IsAlive)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider collider)
    {

        if (activeFog && collider.tag == "Player")
        {
            foreach (GameObject door in Doors)
            {
                door.SetActive(false);
            }
            foreach (GameObject obj in envrionmentObjects)
            {
                obj.SetActive(true);
            }
            fog.SetActive(false);
        }
    }
    #endregion

    #region TOOLS
    // REVENIR ICI CAR CA SERAIT UTILE DE LE FAIRE FONCTIONNER...
    [ContextMenu("Assign all Environment Objects")]
    void AssignEnvironment()
    {
        List<GameObject> props = new List<GameObject>(GameObject.FindGameObjectsWithTag("Environment"));

        foreach (GameObject p in props)
        {
            envrionmentObjects.Add(p);
        }
    }
    #endregion
}