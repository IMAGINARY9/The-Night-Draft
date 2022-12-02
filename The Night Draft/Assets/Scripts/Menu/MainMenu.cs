using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float _titleTime;

    public void PlayGame()
    {
        StartCoroutine(TitleRoutine());
        IEnumerator TitleRoutine()
        {
            yield return new WaitForSeconds(_titleTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
