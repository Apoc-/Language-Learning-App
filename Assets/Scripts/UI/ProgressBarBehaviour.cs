using System.Collections;
using System.Collections.Generic;
using Gamification;
using UnityEngine;

public class ProgressBarBehaviour : MonoBehaviour
{
    public GameObject ProgressObject;

    private float _progress;

    /// <summary>
    /// Sets the current progress of the bar depending on total.
    /// For a progress of 5 with a total of 10 it sets the bar to 50%.
    /// </summary>
    /// <param name="progress"></param>
    /// <param name="total"></param>
    public void SetProgress(int progress, int total)
    {
        var barRect = gameObject.GetComponent<RectTransform>().rect;
        
        var maxWidth = barRect.width;
        var perc = (float) progress / total;
        var width = maxWidth * perc;
        
        ProgressObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
/*
    private int c = 0;
    public void Test()
    {
        switch (c)
        {
            case 0:
                SetProgress(10,10);
                break;
            case 1:
                SetProgress(0,10);
                break;
            case 2:
                SetProgress(5,10);
                break;
            case 3:
                SetProgress(3,10);
                break;
        }

        if (++c > 3) c = 0;
        Debug.Log(c);
    }*/
}
