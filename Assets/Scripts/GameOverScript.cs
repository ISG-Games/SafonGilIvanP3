using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GnivelAll;
    public GameObject GHUD;
    void OnEnable()
    {
        GnivelAll.SetActive(false);
        GHUD.SetActive(false);
        ScoreScript.cScore=0;
        StartCoroutine("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Menu(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TrabajoFinal");
    }
}
