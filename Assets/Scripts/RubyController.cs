using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 20.0f;
    
    // public int maxHealth = 5;

    // public int health { get { return currentHealth; }}
    // int currentHealth;

    public GameObject projectilePrefab;

    Rigidbody2D rigidbody2d;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public ParticleSystem particlesDaño;
    bool level3o4;
    int nivelActual;

    public bool muerto;
    public GameObject GameOver;

    //Tiempo
    public static float tiempoActual;
    public int tiempoMax;
    public GameObject BarraTiempo;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tiempoActual=0;
    }

    void OnEnable(){
        muerto=false;
        level3o4=false;
        nivelActual=MenuScript.levelActual;
        if(nivelActual==3 || nivelActual==4){
            level3o4=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(muerto==true){
            GameOver.SetActive(true);
        }

        tiempoActual+=Time.deltaTime;
        if (tiempoActual>=tiempoMax){
            muerto=true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        Vector2 position = rigidbody2d.position;
        
        position = position + move * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);

        if(level3o4 && Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    void Launch()
    {
         GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

         Projectile projectile = projectileObject.GetComponent<Projectile>();
         projectile.Launch(lookDirection, 300);

         animator.SetTrigger("Launch");
    }
}
