using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickableObject : MonoBehaviour
{

    private void OnMouseDown() {
        if (Input.GetMouseButtonDown(0)){
            on_click();
        }

    }

    public void on_click() {
        double amount = UpgradeManager.Instance.clickAmount * UpgradeManager.Instance.multiplierAmount;
        UpgradeManager.Instance.addPeaches(amount);
    }
}
