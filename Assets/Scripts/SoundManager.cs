using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Animator anime;
    [SerializeField] Slider volumeslider;
    bool muted = false;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            load();
        }
        else
        {
            load();
        }
    }
    
    public void changevolume()
    {
        AudioListener.volume = volumeslider.value;
        save();
    }

    private void load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume",volumeslider.value);
    }

    public void button()
    {
        if(muted == false)
        {
            AudioListener.volume = 0;
            muted = true;
            anime.SetBool("btn",true);
        }
        else
        {
            AudioListener.volume = 1;
            anime.SetBool("btn",false);
            muted = false;
        }
    }
}
