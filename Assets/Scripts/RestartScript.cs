using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void btnRestart_click()
    {
        //Debug.Log("Unload This Scene and load Level One.");
        SceneManager.LoadSceneAsync(0);
    }
}