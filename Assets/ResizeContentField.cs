using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeContentField : MonoBehaviour
{


    public void Resize() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        float height = 0;
        
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();   
        height = gridLayoutGroup.cellSize.y * this.transform.childCount + gridLayoutGroup.spacing.y * (this.transform.childCount - 1);
        
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
    }
}
