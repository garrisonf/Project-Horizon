﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box7Script : MonoBehaviour
{
    public bool activated = false;
    public GameObject[] affectedBoxes = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If the box collider is overlapping with the player's collider
        if (GetComponent<Collider2D>().IsTouching(GameObject.FindWithTag("Player").GetComponent<Collider2D>()))
        {
            // If the user presses space
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("Box 7 pressed");
                // Flip all the switches
                affectedBoxes[0].GetComponent<Box4Script>().activated = !affectedBoxes[0].GetComponent<Box4Script>().activated;
                affectedBoxes[1].GetComponent<Box7Script>().activated = !affectedBoxes[1].GetComponent<Box7Script>().activated;
                affectedBoxes[2].GetComponent<Box8Script>().activated = !affectedBoxes[2].GetComponent<Box8Script>().activated;
            }
        }

        if (activated)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 250f, 0f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        }
    }
}
