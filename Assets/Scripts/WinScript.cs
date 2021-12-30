using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TscoreWin;
    public GameObject WnivelAll;
    public GameObject WHUD;
    int puntuacion;
    void OnEnable()
    {
        WnivelAll.SetActive(false);
        WHUD.SetActive(false);

        puntuacion=ScoreScript.cScore;
        TscoreWin.text=puntuacion+"/10";
        ScoreScript.winScoreInt=MenuScript.levelActual;
        StartCoroutine("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Menu(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TrabajoFinal");
    }
}
