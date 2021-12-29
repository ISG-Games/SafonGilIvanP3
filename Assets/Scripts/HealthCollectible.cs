using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem Effect;
    void OnTriggerEnter2D(Collider2D other){
         RubyController controller = other.GetComponent<RubyController>();

         if (controller != null)
         {
            Instantiate(Effect, transform.position, Quaternion.identity);
            ScoreScript.cScore+=1;
            UIHealthBar.instance.SetValue((float)ScoreScript.cScore / (float)10);
            Destroy(gameObject);
        }
    }
}
