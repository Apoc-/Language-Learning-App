using System.Collections.Generic;
using DataProvider;
using Gamification;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class ProfileCanvas : MonoBehaviour
    {
        public GameObject Name;
        public GameObject Level;
        public GameObject TrophyPrefab;
        public GameObject TrophyContainer;

        private void ResetTrophies()
        {
            foreach (Transform child in TrophyContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                GamificationManager.Instance.HandleAnsweredQuestion(true);
            }
            if (Input.GetKey(KeyCode.Keypad0))
            {
                var user = GamificationManager.Instance.User;
                user.Level = 1;
                user.Trophies = new List<TrophyType>();
            }
        }

        private void OnEnable()
        {
            ResetTrophies();
            
            ViewHandler.Instance.NavigationDrawer.EnableHomeButton();
            var user = GamificationManager.Instance.User;
            //Name.GetComponent<Text>().text = user.Name;
            //todo fix
            Name.GetComponent<Text>().text = "Chuck Norris";
            Level.GetComponent<Text>().text = "Level " + user.Level;

            LoadUserTrophies();
        }

        private void LoadUserTrophies()
        {
            var trophies = GamificationManager.Instance.User.Trophies;
            
            trophies.ForEach(InitializeTrophyEntry);
        }

        private void InitializeTrophyEntry(TrophyType type)
        {
            var trophy = GamificationManager.Instance.TrophyHandler.GetTrophyByType(type);
            var button = Instantiate(TrophyPrefab, TrophyContainer.transform).GetComponent<TrophyButton>();
            
            button.Trophy = trophy;
            button.GetComponent<Image>().sprite = trophy.Image;
        }
    }
}