using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WinObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            WinObject.SetActive(true);
        }
    }
}
