using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gnivel1;
    public GameObject Gnivel2;
    public GameObject Gnivel3;
    public GameObject Gnivel4;
    public GameObject GnivelAll;
    public GameObject GHUD;
    public GameObject GMenu;
    public GameObject GRuby;
    void OnEnable()
    {
        Gnivel1.SetActive(false);
        Gnivel2.SetActive(false);
        Gnivel3.SetActive(false);
        Gnivel4.SetActive(false);
        GnivelAll.SetActive(false);
        GHUD.SetActive(false);
        ScoreScript.cScore=0;
        GRuby.transform.position=new Vector3(2,-8.5f,0);
        StartCoroutine("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Menu(){
        yield return new WaitForSeconds(2);
        GMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
