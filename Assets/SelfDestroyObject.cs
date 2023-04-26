using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyObject : MonoBehaviour
{
    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
