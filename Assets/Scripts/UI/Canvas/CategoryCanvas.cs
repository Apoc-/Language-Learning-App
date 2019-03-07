using System.Collections.Generic;
using DataProvider;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class CategoryCanvas : MonoBehaviour
    {
        public GameObject CategoryItemPrefab;
        public List<Category> CategoryData = new List<Category>();
        public GameObject Table;
   
        private void OnEnable()
        {
            ResetTable();
            CategoryData = DataCache.Instance.GetCategoriesByClassType(ViewHandler.Instance.CurrentClass);

            foreach (var item in CategoryData)
            {
                GameObject row = Instantiate(CategoryItemPrefab, Table.transform);
                row.name = item.Id;

                var user = Gamification.GamificationManager.Instance.User;
                var text = "";
                if (user.UiLanguage == Language.German)
                {
                    text = item.Name.German;
                } else
                {
                    text = item.Name.Chinese;
                }

                row.GetComponentInChildren<Text>().text = text;
            }
        }
    
        private void ResetTable()
        {
            foreach (Transform child in Table.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void CategorySelect()
        {
            var selected = EventSystem.current.currentSelectedGameObject.name;
            switch (selected)
            {
                case "ReturnButton":
                    ViewHandler.Instance.LearnOrDictionary = ViewHandler.LearnOrDic.None;
                    ViewHandler.Instance.SwitchToView("Dictionary or Learning");
                    break;

                default:
                    Debug.Log("Dictionary or Learning button select Error");
                    break;

            }
        }

    }
}