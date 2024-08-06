using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public GhostMovement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter{ get; private set; }
    public GhostChase chase{ get; private set; }
    public GhostFrightened frightened{ get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;


    private void Start()
    {
        this.movement = GetComponent<GhostMovement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
       // this.movement.ResetState();
        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        
        if (this.home != this.initialBehavior) 
        {
            this.home.Disable();
        }
        if (this.initialBehavior != null) 
        {
            this.initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        position.z = this.transform.position.z;
        this.transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!this.frightened.enabled) 
            {
                FindObjectOfType<Movement>().CircleEaten();
            }
        }
    }
}