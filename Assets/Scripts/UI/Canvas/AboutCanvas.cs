using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class AboutCanvas : MonoBehaviour
    {
  

        private void OnEnable()
        {
            
            ViewHandler.Instance.NavigationDrawer.EnableHomeButton();
            

        }
    }
}