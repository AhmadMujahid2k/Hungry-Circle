using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void btnStart_click()
    {
        Debug.Log("Unload This Sence and load Level One.");
        SceneManager.LoadSceneAsync(1);
    }
}
