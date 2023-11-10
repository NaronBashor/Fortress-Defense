using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
        [SerializeField] private string sceneName;
        [SerializeField] private string buttonType;

        public void ChangeScene()
        {
                if (buttonType != null)
                {
                        if (buttonType == "Restart")
                        {
                                GameObject.Find("ExperienceManager").GetComponent<ExperienceManager>().ResetValues = true;
                        }
                }
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                if (Time.timeScale == 0)
                {
                        Time.timeScale = 1;
                }
        }
}
