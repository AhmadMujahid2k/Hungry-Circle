using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject Scene;
    [SerializeField] Vector2 initialDirection;
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float FrighteningTime;


    public float speedstoper;
    public Ghost[] ghosts;
    public LayerMask wall;
    private Vector2 direction;
    private Vector2 nextDirection ;

    private int score;
    private int live;
	[SerializeField] Text txtScore;
	[SerializeField] Text txtLive;
    [SerializeField] Animator anime;
    private float speedtemp;

    private void Start()
    {
        live =3;
        direction = initialDirection;
        nextDirection = Vector2.zero;
    }

    private void Update()
    {

        if(live == 0)
        {
            Scene.GetComponent<SFX>().SceneChangeFunction();
              SceneManager.LoadSceneAsync(6);
              
        }
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                anime.SetBool("StartAnimation",true);
                SetDirection(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                anime.SetBool("StartAnimation",true);
                SetDirection(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anime.SetBool("StartAnimation",true);
                SetDirection(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                anime.SetBool("StartAnimation",true);
                SetDirection(Vector2.right);
            }

            // Rotate pacman to face the movement direction
            float angle = Mathf.Atan2(direction.y, direction.x);
            this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    private void FixedUpdate()
    {
        Vector2 position = rgb.position;
        rgb.MovePosition(position + direction * speed * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 direction ,bool forced = false)
    {
        if (forced ||!Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, wall);
        return hit.collider != null;
    }

    public void CircleEaten()
    {
        anime.SetBool("Death",true);
        speedstoper = speed;
        speed = 0;
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].SetPosition(this.ghosts[i].home.inside.position);
            this.ghosts[i].home.Enable(0);
        }
        Invoke("respawner",2);
        live--;
        Scene.GetComponent<SFX>().PlayerDeathFunction();
		txtLive.text = "Lives: " + live.ToString();

    }
    public void respawner()
    {
        player.localPosition = new Vector3(-2.5f,-10.25f,0);
        speed = speedstoper;
        anime.SetBool("Death",false);
        anime.SetBool("respawn",true);
        speedtemp =speed;
        speed = 0;
        StartCoroutine(waiter());
    }
      IEnumerator waiter()
    {
        yield return new WaitForSeconds(2.3f);
        speed = speedtemp;
    }
    public void scoreEnemyKills()
    {
        score = score + 200;
		txtScore.text = "Score: " + score.ToString();
    }
     private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Dots"))
        {
            Scene.GetComponent<SFX>().EatFunction();
			score = score + 10;
			Destroy(other.gameObject);
			txtScore.text = "Score : " + score.ToString();
        }
		if(other.gameObject.CompareTag("Power"))
        {
			score = score + 50;
			Destroy(other.gameObject);
			txtScore.text = "Score : " + score.ToString();
        }
         if(other.gameObject.CompareTag("Power"))
        {
            
            for (int i = 0; i < this.ghosts.Length; i++)
            {
            this.ghosts[i].frightened.Enable(FrighteningTime);
            this.ghosts[i].movement.speedMultiplier = 0.5f;
             }
        
        }
	}
}
