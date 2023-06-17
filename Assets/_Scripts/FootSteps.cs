using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    [SerializeField] private AudioSource footstepSound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.S))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
