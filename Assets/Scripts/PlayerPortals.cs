using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPortals : MonoBehaviour
{
    [SerializeField] Transform playerrgb;
  
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Portals"))
        {
			playerrgb.localPosition = new Vector3(-15,-1,0);
        }
        if(other.gameObject.CompareTag("Portals 2"))
        {
			playerrgb.localPosition = new Vector3(10,-1,0);
        }
	}
    
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Portals"))
        {
			playerrgb.localPosition = new Vector3(-15,-1,0);
        }
        if(other.gameObject.CompareTag("Portals 2"))
        {
			playerrgb.localPosition = new Vector3(10,-1,0);
        }
	}
}
