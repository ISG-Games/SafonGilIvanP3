using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image BarraTiempoMask;
    float originalSize;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tiempoActual=0;

        originalSize = BarraTiempoMask.rectTransform.rect.width;
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
        //Muerto?
        if(muerto==true){
            GameOver.SetActive(true);
        }

        //Tiempo
        tiempoActual+=Time.deltaTime;
        if (tiempoActual>=tiempoMax+0.5f){//tiempoMax+0.5 para que tengas medio segundo más de tiempo del que crees
            muerto=true;
        }
        SetValueTimeBar( (float)(tiempoMax-tiempoActual) / (float)tiempoMax );

        //Movimiento
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

        //Disparar
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

    void SetValueTimeBar(float value)
    {				      
        BarraTiempoMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
