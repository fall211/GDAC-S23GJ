using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsTicker : MonoBehaviour
{
    public int totalPeaches;

    [System.Serializable]
    public struct News
    {
        public string content;
        public double peachThreshold;
    };

    [SerializeField]
    public List<News> newsTicker = new List<News>();

    public int currentNews;

    [SerializeField] private TextMeshProUGUI scrollingTMP;
    [SerializeField] private float scrollSpeed;
    private TextMeshProUGUI scrollingTMPClone;
    private RectTransform textRT;
    private float width;
    private Vector3 startPos;

    public int textState;
    public int textCloneState;

    private void Awake()
    {
        textRT = scrollingTMP.GetComponent<RectTransform>();
        width = scrollingTMP.preferredWidth;
        startPos = textRT.anchoredPosition;

        scrollingTMPClone = Instantiate(scrollingTMP);
        RectTransform cloneRT = scrollingTMPClone.GetComponent<RectTransform>();
        cloneRT.SetParent(textRT);
        cloneRT.anchorMin = new Vector2(1, .5f);
        cloneRT.localScale = new Vector3(1, 1, 1);
        cloneRT.anchoredPosition = new Vector2(0, textRT.anchoredPosition.y);
    }

    private void Update()
    {
        foreach (News n in newsTicker)
        {
            if (totalPeaches >= n.peachThreshold && currentNews < newsTicker.IndexOf(n))
            {
                currentNews = newsTicker.IndexOf(n);
            }
        }

        /*if (scrollingTMP.havePropertiesChanged)
        {
            width = scrollingTMP.preferredWidth;
            scrollingTMPClone.text = scrollingTMP.text;
        }*/

        textRT.anchoredPosition = Vector2.MoveTowards(textRT.anchoredPosition, new Vector2(
            textRT.anchoredPosition.x - startPos.x, textRT.anchoredPosition.y), scrollSpeed * Time.deltaTime);

        if (textRT.anchoredPosition.x <= width * -1 + startPos.x)
        {
            textRT.anchoredPosition = new Vector2(startPos.x, textRT.anchoredPosition.y);

            if (textCloneState == textState)
            {
                scrollingTMPClone.text = newsTicker[currentNews].content;
                textCloneState = currentNews;
            }
            else
            {
                scrollingTMP.text = newsTicker[currentNews].content;
                textState = currentNews;
            }

            width = scrollingTMP.preferredWidth;
        }
    }


    // Start is called before the first frame update
    /*void Start()
    {
        StartCoroutine(DisplayNews());
    }

    IEnumerator DisplayNews()
    {
        updateNews = false;
        for(int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.1f);
            newsObject.transform.localPosition = Vector3.Lerp(route[0], route[1], i / 50);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            newsObject.transform.localPosition = Vector3.Lerp(route[1], route[2], i / 100);
        }

        updateNews = true;

        yield return new WaitForSeconds(3f);

        StartCoroutine(DisplayNews());
    }

    IEnumerator UpdateNews()
    {
        while(!updateNews)
        {
            yield return null;
        }

        newsText.text = newsTicker[currentNews].content;
    }*/
}
