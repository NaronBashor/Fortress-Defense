using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
        [SerializeField] private Button continueButton;
        [SerializeField] private GameObject areYouSurePanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject settingsBlackBackground;

        private void Start()
        {
                areYouSurePanel.SetActive(false);
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();

                if (!DataPersistenceManager.Instance.HasGameData())
                {
                        continueButton.interactable = false;
                }
        }

        public void OnNewGame()
        {
                areYouSurePanel.SetActive(true);
        }

        public void CloseAreYouSurePanel()
        {
                areYouSurePanel.SetActive(false);
        }

        public void OnNewGameConfirm()
        {
                DataPersistenceManager.Instance.NewGame();
                SceneManager.LoadSceneAsync("LevelSelect");
        }

        public void OnContinue()
        {
                SceneManager.LoadSceneAsync("LevelSelect");
        }

        public void QuitGame()
        {
                Application.Quit();
        }

        public void OnSettings()
        {
                settingsPanel.SetActive(true);
                settingsBlackBackground.SetActive(true);
        }
}
