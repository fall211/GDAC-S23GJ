using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeachesTxtUpdate : MonoBehaviour
{

    public void updateCount(int peaches){
        GetComponent<TextMeshProUGUI>().text = peaches.ToString();
    }
}
