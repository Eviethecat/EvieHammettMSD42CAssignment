using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    [SerializeField] AudioClip scoreUp;
    [SerializeField] [Range(0, 1)] float scoreUpVolume = 0.5f;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        AudioSource.PlayClipAtPoint(scoreUp, Camera.main.transform.position, scoreUpVolume);

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
