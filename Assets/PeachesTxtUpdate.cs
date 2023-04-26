using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;

public class PeachesTxtUpdate : MonoBehaviour
{

    public void updateCount(BigDouble peaches){
        GetComponent<TextMeshProUGUI>().text = peaches.ToString("F0");
    }
}
