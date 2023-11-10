using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
        [SerializeField] private CinemachineVirtualCamera m_Camera;
        [SerializeField] private float cameraMoveRange;
        [SerializeField] private GameObject pauseGamePanel;

        private int index = 1;

        private void Awake()
        {
                pauseGamePanel.SetActive(false);
        }

        public void OnCameraMoveLeft(InputAction.CallbackContext ctx)
        {
                if (m_Camera != null)
                {
                        if (m_Camera.transform.position.x > -38)
                        {
                                if (ctx.started)
                                {
                                        m_Camera.transform.Translate(Vector2.left * cameraMoveRange);
                                }
                        }
                }
        }

        public void OnCameraMoveRight(InputAction.CallbackContext ctx)
        {
                if (m_Camera != null)
                {
                        if (m_Camera.transform.position.x < 1.4)
                        {
                                if (ctx.started)
                                {
                                        m_Camera.transform.Translate(Vector2.right * cameraMoveRange);
                                }
                        }
                }
        }

        public void FastForward()
        {
                if (index == 1)
                {
                        Time.timeScale = 2;
                        index = 2;
                        pauseGamePanel.SetActive(false);
                }
                else if (index == 2)
                {
                        Time.timeScale = 1;
                        index = 1;
                        pauseGamePanel.SetActive(false);
                }
        }

        public void PauseGame()
        {
                if (Time.timeScale == 1 || Time.timeScale == 2)
                {
                        Time.timeScale = 0;
                        pauseGamePanel.SetActive(true);
                }
                else if (Time.timeScale == 0)
                {
                        Time.timeScale = 1;
                        pauseGamePanel.SetActive(false);
                }
        }

        public void PlayGame()
        {
                if (Time.timeScale != 1 || Time.timeScale != 2)
                {
                        Time.timeScale = 1;
                        pauseGamePanel.SetActive(false);
                }
        }
}
