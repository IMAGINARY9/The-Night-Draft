using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused;
        [SerializeField] private GameObject _pauseMenuUI;
        [SerializeField] private GameObject _gameOverMenuUI;
        public static event Action GameRestart;

        private void Start()
        {
            Player.PlayerDied += GameOver;
            LevelManager.GameOver += GameOver;
        }

        void Update()
        {
            //if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (GameIsPaused)
                        Resume();
                    else
                        Pause();
                }
            }
        }

        public void Restart()
        {
            Player.PlayerDied -= GameOver;
            GameRestart?.Invoke();
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Pause()
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        public void GameOver()
        {
            Player.PlayerDied -= GameOver;
            _gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void QuitToMainMenu()
        {
            Player.PlayerDied -= GameOver;
            GameRestart?.Invoke();
            Time.timeScale = 1f;
            var index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index - index);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}