﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class dialog : MonoBehaviour
{


    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject skipButton;


    IEnumerator Type()
    {        
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            Debug.Log("Next iteration");
        }
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Type());        
    }



    void Update()
    {       
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

    }

    public void SkipToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            skipButton.SetActive(false);
            continueButton.SetActive(false);
            SceneManager.LoadScene("SampleScene");            
            textDisplay.text = "";
        }
    }

}