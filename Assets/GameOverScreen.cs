using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public Asteroid asteroidPrefab;
    public void Setup(int score)
    {
        Debug.Log("game over screen scene index  " + SceneManager.GetActiveScene().buildIndex);
        Destroy(asteroidPrefab);

        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("StartGameAnimationScene");
    }

}
