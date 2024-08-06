using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostFrightened : GhostBehavior
{
    [SerializeField] Animator anime;
    [SerializeField] Transform ghostT;
    [SerializeField] GameObject Scene;
    [SerializeField] Collider2D collider;

    private void Start() 
    {
       
    }

    private void Update()
    {
 
    }
   

    public override void Enable(float duration)
    {
        base.Enable(duration);
        anime.SetBool("Frightening",true);
    }

    public override void Disable()
    {
        this.ghost.movement.speedMultiplier = 1f;
        anime.SetBool("Frightening",false);
        base.Disable();
    }

    private void Eaten()
    {
        FindObjectOfType<Movement>().scoreEnemyKills();
        anime.SetBool("d",true);
        Scene.GetComponent<SFX>().GhostDeathFunction();
        collider.enabled = false;
        this.ghost.movement.speedMultiplier = 0f;
        StartCoroutine(waiter());
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Junktions jun = other.GetComponent<Junktions>();

        if (jun != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            
            foreach (Vector2 availableDirection in jun.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (this.enabled) 
            {
                Eaten();
                
                
            }
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
        this.ghost.movement.speedMultiplier = 1f;
        this.ghost.SetPosition(this.ghost.home.inside.position);
        collider.enabled = true;
        anime.SetBool("d",false);
        this.ghost.home.Enable(0);
    }
}
