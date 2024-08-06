using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DotCount : MonoBehaviour
{
    [SerializeField] GameObject main;
    void Start()
    {

    }
    void Update()
    {
        Debug.Log(main.name + " has " + main.transform.childCount + " children");
        if(main.transform.childCount == 0)
        {
            SceneManager.LoadSceneAsync(5);
        }
    }
}
