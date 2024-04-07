using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    //After this time, the object will be distroyed
    [Header("Defult Destruction Time")]
    public float timeToDestruction;
    // Start is called before the first frame update
    void Start()
    {
         //Execute DestroyObject function based on timeToDestruction
        Invoke("DestroyObject", timeToDestruction);
    }

    //n This function will distroy this object
    void DestroyObject()
    {
         //Destroy object
         Destroy(gameObject);
    }
}

