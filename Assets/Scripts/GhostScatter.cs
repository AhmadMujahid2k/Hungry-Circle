using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostScatter : GhostBehavior
{
    private void Start() 
    {
        
    }

    private void Update() 
    {
        
    }

    private void OnDisable()
    {
        this.ghost.chase.Enable(); 
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Junktions jun = other.GetComponent<Junktions>();

        if (jun != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, jun.availableDirections.Count);
            if (jun.availableDirections[index] == -this.ghost.movement.direction && jun.availableDirections.Count > 1)
            {
                index++;
                if (index >= jun.availableDirections.Count)
                {
                    index = 0;
                }
            }
            this.ghost.movement.SetDirection(jun.availableDirections[index]);
        }
    }
}
