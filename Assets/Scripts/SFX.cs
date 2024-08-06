using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFX : MonoBehaviour
{
    public AudioSource Eat;

    public AudioSource PlayerDeath;
    public AudioSource GhostDeath;

    public AudioSource SceneChange;
    private void Start()
    {

    }

    private void Update()
    {

    }

    public void EatFunction()
    {
        Eat.Play();
    }
    public void PlayerDeathFunction()
    {
        PlayerDeath.Play();
    }
    public void GhostDeathFunction()
    {
        GhostDeath.Play();
    }
    
    public void SceneChangeFunction()
    {
        SceneChange.Play();
    }
}