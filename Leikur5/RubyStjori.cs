using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

﻿public class RubyStjori : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    
    public GameObject projectilePrefab;
    
    public int health { get { return currentHealth; }}
    int currentHealth;
    
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public Text countText;
    public static int count;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        count = 0;
        SetCountText();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        // Breytir stefnuni á animaterinum
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        // kastar tannhjóli
        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        // ef gimsteinatalið er minna eða jafnt og -1 byrjar maður aftur frá byrjun
        if(count <= -1)
        {
            SceneManager.LoadScene("Start");
        }

        // Telur gimsteina
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Coin");

        if (gameObjects.Length == 0)
        {
            SceneManager.LoadScene("END");
        }
    }
    
    // Lagar stöðu leikmans
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    
    // Kastar Tannhjóli
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }

    //Skrifar gimsteinatal
    void SetCountText()
    {
        countText.text = "Gems: " + count.ToString();

        //Ef stigin eru 6 eða fleirri
        if(count >= 3)  
        {
            SceneManager.LoadScene("END");
        }
    }


    // ef rekst er á óvin eða gimstein(Coin) og hækkar og lækkar talið eftir hvað rekst er á
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Coin")
        {
            Debug.Log(count);
            other.collider.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.collider.tag == "Enemy")
        {
            Debug.Log(count);
            count = count - 1;
            SetCountText();
        }
    }
}
