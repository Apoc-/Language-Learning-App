using System;
using DataAccess;
using UnityEngine;
using UnityEngine.UI;

namespace DataProvider
{
    [RequireComponent(typeof(Text))]
    public class TranslatorComponent : MonoBehaviour
    {
        public string Key;

        private void OnEnable()
        {
            var textComponent = GetComponent<Text>();
            var text = textComponent.text;
            try
            {
                text = DataCache.Instance.GetUiTranslationByKey(Key);
            }
            catch (Exception ex)
            {
                Debug.LogError("Translation key " + Key + " not found.");
            }

            textComponent.text = text;
        }
    }
}