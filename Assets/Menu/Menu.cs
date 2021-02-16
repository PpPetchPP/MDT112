using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public Animator anima;
    bool intro = true;
    bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip; 
    }

    // Update is called once per frame
    void Update()
    {
        anima.SetBool("Intro", intro);
        anima.SetBool("Play", play);
    }

    public void clickplay()
    {
        audioSource.Play();
        play = true;
        Invoke("Load", 2f);
    }
    public void clickexit()
    {
        audioSource.Play();
        Application.Quit();
    }

    private void Load()
    {
        SceneManager.LoadScene(1);
    }
}
