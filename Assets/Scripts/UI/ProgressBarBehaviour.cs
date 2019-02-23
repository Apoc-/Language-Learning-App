using UnityEngine;

namespace UI
{
    public class ProgressBarBehaviour : MonoBehaviour
    {
        public GameObject ProgressObject;

        private float _progress = 0;
        private int _size = 10;

        /// <summary>
        /// Sets the size of the bar to size units
        /// </summary>
        /// <param name="size"></param>
        public void SetProgressBarSize(int size)
        {
            _size = size;
            UpdateProgressBar();
        }
        
        /// <summary>
        /// Sets the current progress of the bar depending on total.
        /// For a progress of 5 with a total of 10 it sets the bar to 50%.
        /// </summary>
        /// <param name="progress"></param>
        public void SetProgress(int progress)
        {
            _progress = progress;
            UpdateProgressBar();
        }

        public void IncrementProgressBar()
        {
            _progress += 1;
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            var barRect = gameObject.GetComponent<RectTransform>().rect;
        
            var maxWidth = barRect.width;
            var perc = _progress / _size;
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
}
