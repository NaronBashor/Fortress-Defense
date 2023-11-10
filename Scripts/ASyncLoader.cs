using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncLoader : MonoBehaviour
{
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private GameObject mainMenu;

        [SerializeField] private Image loadingBar;

        private float progressValue;

        public void LoadLevelButton(string levelToLoad)
        {
                mainMenu.SetActive(false);
                loadingScreen.SetActive(true);

                StartCoroutine(LoadLevelASync(levelToLoad));
        }

        IEnumerator LoadLevelASync(string levelToLoad)
        {
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

                while (!loadOperation.isDone)
                {
                        progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
                        loadingBar.fillAmount = progressValue;
                        yield return null;
                }
        }
}
