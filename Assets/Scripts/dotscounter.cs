using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dotscounter : MonoBehaviour
{
    [SerializeField] GameObject dots;

    void Start()
    {
      

    }

    void Update()
    {
        if(dots.transform.childCount == 0)
        {
             SceneManager.LoadSceneAsync(2);
        }
    }
}
