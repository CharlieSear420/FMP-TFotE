using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    public CharacterController controller;

    public float PlayerSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public int maxHealth = 100;
    public int currentHealth;
    public health healthBar;
    public Text healthText;


    void start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * PlayerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}

        //string myString = myInt.ToString();
        healthText.text = currentHealth.ToString();
        
    }

    
    //void OnCollisionEnter(Collision collision)
    public void OnControllerColliderHit(ControllerColliderHit collision)
    {
      	string player = collision.gameObject.tag;
        print (player);
       	if (player == "bunker")
       	{
            Debug.Log ("victory");
            //Application.Quit();
            SceneManager.LoadScene("Victory");
       	}

        string person = collision.gameObject.tag;
       	if (player == "enemy")
       	{
            Debug.Log ("damage taken");
            TakeDamage(5);
       	}
        
        string dude = collision.gameObject.tag;
        if (player == "health pack")
        {
            Debug.Log("Health gained");
            HealHealth(10);
        }
        
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0f)
        {
            Debug.Log("dead");
            //Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
            SceneManager.LoadScene("Death");
        }
    }


    void HealHealth (int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

}
