using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void btnoption_click()
    {
        Debug.Log("Unload This Sence and load options.");
        SceneManager.LoadSceneAsync(7);
    }
}