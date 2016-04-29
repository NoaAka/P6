using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public int energy = 100;
    public float rotation;

    void Update()
    {
        transform.Rotate(0,rotation * Time.deltaTime, 0) ;
    }
}
