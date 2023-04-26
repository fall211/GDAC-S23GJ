using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;

public class ClickableObject : MonoBehaviour
{
    public Vector2 topLeft;
    public Vector2 bottomRight;

    public GameObject peachPrefab;

    public float smallScale;
    public float largeScale;

    public AudioClip clickSound;

    public AudioSource audioSource;

    private void OnMouseDown() {
        if (Input.GetMouseButtonDown(0)){
            on_click();
        }
    }

    public void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.gameObject.transform.localScale = new Vector3(largeScale, largeScale, largeScale);
        }
    }


        public void on_click() {
        BigDouble amount = UpgradeManager.Instance.clickAmount * UpgradeManager.Instance.multiplierAmount;
        UpgradeManager.Instance.addPeaches(amount);
        Instantiate(peachPrefab, transform.position + (Vector3)new Vector2(Random.Range(topLeft.x, bottomRight.x), Random.Range(topLeft.y, bottomRight.y)), Quaternion.identity).GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(Random.Range(topLeft.x, bottomRight.x), Random.Range(topLeft.y, bottomRight.y)), ForceMode2D.Impulse);
        this.gameObject.transform.localScale = new Vector3(smallScale, smallScale, smallScale);
        audioSource.PlayOneShot(clickSound);
    }


}
