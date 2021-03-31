using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public string infoText;
    [Range(19,100)]
    public float panelWidth = 72;
    [Range(0,1)]
    public float widthPercent = 0;
    float oldWidthPercent;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        oldWidthPercent = widthPercent = 0;
        AdjustWidth(widthPercent);
    }

    // Update is called once per frame
    void Update()
    {
        if (widthPercent != oldWidthPercent)
        {
            AdjustWidth(widthPercent);
            oldWidthPercent = widthPercent;
        }
    }

    void AdjustWidth(float percent) {
        float width = 19 + ((panelWidth - 19) * percent);
        //rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
