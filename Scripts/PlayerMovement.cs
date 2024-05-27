using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D colSword;

    private Rigidbody2D rigidBodyPlayer;
    private Animator anim;
    private SpriteRenderer spriteCharacter;
    private float posColX = 0.4f;
    private float posColY = 0;
    private int playerHealth = 3;
    private bool talking;

    [SerializeField] UIManager uIManager;

    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        
        //Set the key to attack 
        if (Input.GetMouseButtonDown(0) && talking == false)
        {
            anim.SetTrigger("Attack");
        }

        // I set k to taste the wound of the player
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Wound();
        }

    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void ImTalking(bool talk)
    {
        talking = talk;
    
    }

    void Movement()
    {
        //Add the control of the player in axis(eje) "Horizontal" and "Vertical" (x,y)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (talking == false)
        {
            //Add velocity of the player.
            rigidBodyPlayer.velocity = new Vector2(horizontal, vertical) * speed;

            //Add animation.
            anim.SetFloat("Walk", Mathf.Abs(rigidBodyPlayer.velocity.magnitude));
        }

        // flip the animation if the axis horizontal < 0
        if (horizontal > 0)
        {
            //add posColX and posColY to flip the boxcollider2D of the sword too
            colSword.offset = new Vector2(posColX, posColY);
            spriteCharacter.flipX = false;
        }
        else if (horizontal < 0)
        {    
            colSword.offset = new Vector2(-posColX, posColY);
            spriteCharacter.flipX = true;
        }

    }

    public void Wound() 
    {
        //Set the life of the player

      if (playerHealth > 0) 
        {
            //Rest of the player life
            playerHealth--;
            uIManager.RestHearts(playerHealth);

            //if life of the player == 0 set the animation of die and destroy the playerGameObject
            if (playerHealth == 0)
            {
                
                anim.SetTrigger("Die");
                Invoke(nameof(Die), 1f);
                RestartGame();
            }
        
        }
    
    }
    public void Heal()
    {
        if(playerHealth < 3) 
        {
         uIManager.AddHearths (playerHealth);
            playerHealth++;
        
        }

    }


    //Destroy the player if the player life == 0
    private void Die() 
    {
    Destroy(this.gameObject);
    }

    public void RestartGame() 
    {
        
        SceneManager.LoadScene("TreeLand");
    }
}
