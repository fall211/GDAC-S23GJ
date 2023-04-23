using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Invoke("DestroyThis", 3);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
