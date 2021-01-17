using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    IEnumerator WaitAndLoadLose()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadLose());
    }

    IEnumerator WaitAndLoadWin()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameWon");
    }

    public void LoadGameWin()
    {
        StartCoroutine(WaitAndLoadWin());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        //will only work on EXE game
        Application.Quit();
    }
}