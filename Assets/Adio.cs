﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adio : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            audioSource.Play();
        }
    }
}
