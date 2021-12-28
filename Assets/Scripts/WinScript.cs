using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TscoreWin;
    public GameObject Wnivel1;
    public GameObject Wnivel2;
    public GameObject Wnivel3;
    public GameObject Wnivel4;
    public GameObject WnivelAll;
    public GameObject WHUD;
    public GameObject WMenu;
    public GameObject WRuby;
    int puntuacion;
    void OnEnable()
    {
        Wnivel1.SetActive(false);
        Wnivel2.SetActive(false);
        Wnivel3.SetActive(false);
        Wnivel4.SetActive(false);
        WnivelAll.SetActive(false);
        WHUD.SetActive(false);
        WRuby.transform.position=new Vector3(2,-8.5f,0);

        puntuacion=ScoreScript.cScore;
        TscoreWin.text="Score: "+puntuacion+"/10";
        ScoreScript.winScoreInt=MenuScript.levelActual;
        StartCoroutine("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Menu(){
        yield return new WaitForSeconds(4);
        WMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
