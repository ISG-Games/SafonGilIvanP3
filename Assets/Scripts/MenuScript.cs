using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject AllLevels;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Creditos;
    public GameObject HUD;

    public static int levelActual;

    // Start is called before the first frame update
    void Start()
    {
        levelActual=0;
        AllLevels.SetActive(false);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Creditos.SetActive(false);
        HUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelActual==1){
            Level1.SetActive(true);
            EntrarACualquierNivel();
        }
        if (levelActual==2){
            Level2.SetActive(true);
            EntrarACualquierNivel();
        }
        if (levelActual==3){
            Level3.SetActive(true);
            EntrarACualquierNivel();
        }
    }

    public void IrALevel1(){
        levelActual=1;
    }
    public void IrALevel2(){
        levelActual=2;
    }
    public void IrALevel3(){
        levelActual=3;
    }
    public void IrACredits(){
        Creditos.SetActive(true);
    }
    public void IrAMenu(){
        Creditos.SetActive(false);
    }

    void EntrarACualquierNivel(){
        HUD.SetActive(true);
        AllLevels.SetActive(true);
        gameObject.SetActive(false);
    }
}
