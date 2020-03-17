﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject interactionSprite = null;
    [SerializeField] private GameObject[] consumables = null;

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if (interactionSprite != null)
                interactionSprite.SetActive(true);

            if (collider.GetComponent<Player>().isInteracting == true)
            {
                int randomIndex = Random.Range(0, consumables.Length);
                Instantiate(consumables[randomIndex].gameObject, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (interactionSprite != null)
            interactionSprite.SetActive(false);
    }
}