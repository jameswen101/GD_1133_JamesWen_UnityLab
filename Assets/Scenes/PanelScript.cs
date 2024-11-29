using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelScript : MonoBehaviour
{
    RectTransform rectT;

    private void Awake()
    {
        rectT = GetComponent<RectTransform>();
    }

    public void Open()
    {
        rectT.DOAnchorPosX(0, 0.5f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            GetComponent<Image>().color = Color.yellow; //can use RGB values as well
        });
    }

    public void Close()
    {
        rectT.DOAnchorPosX(-rectT.rect.width, 0.5f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            GetComponent<Image>().color = Color.blue;
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
