using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;
    [SerializeField] float timee;

    private void Start()
    {
        
    }

    private void Update() 
    {
        
    }

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        StartCoroutine(ExitTransition());
    }

    private IEnumerator ExitTransition()
    {
       
        this.ghost.movement.SetDirection(Vector2.up);
        this.ghost.movement.rgb.isKinematic = true;
        Vector3 position = this.transform.position;


        float counter = 0.0f;
        while (counter < timee)
        {
            this.ghost.SetPosition(Vector3.Lerp(position, this.inside.position, counter / timee));
            counter += Time.deltaTime;
            yield return null;
        }

        counter = 0.0f;
        while (counter < timee)
        {
            this.ghost.SetPosition(Vector3.Lerp(this.inside.position, this.outside.position, counter / timee));
            counter += Time.deltaTime;
            yield return null;
        }

        // < 0.5 mean if less than half ? -1 mean go to left other wise 1 mean go to right and making y 0.
        this.ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f));
        this.ghost.movement.enabled = true;
    }

}
