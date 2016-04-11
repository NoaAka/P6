using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    
    public void TurnOn()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
    public void TurnOff()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }//shield low 0.05 startlifetime to 0.2


    public void ShieldLevel(int health)
    {
        //print("Debug shield anim");

        //max health for animation 100
        float startSize = 0;

        float shieldLowRange = 0.6f - 0.05f;
        //scale to range 
        float scaleOffset = 0.05f;

        int maxHealth = 200;

        startSize = (((Mathf.Clamp((float)health, 0, maxHealth)) / maxHealth));
        //print("start lifetime0 : " + lifeTime);

        startSize *= shieldLowRange;
        //print("start lifetime1 : " + lifeTime);

        startSize += scaleOffset;

        //print("start lifetime2 : " + lifeTime);

        GetComponentInChildren<ParticleSystem>().startSize = startSize;
    }

}
