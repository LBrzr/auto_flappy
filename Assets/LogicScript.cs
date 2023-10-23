using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public bool isAlive = true;
    public Text scoreText;
    public GameObject gameOverScreen;

    private List<GameObject> pipes = new List<GameObject>();

    [ContextMenu("Increase score")]
    public void addScore(int value = 1)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isAlive = false;
    }

    public void addPipe(GameObject pipe)
    {
        pipes.Add(pipe);
    }

    public void removePipe(GameObject pipe)
    {
        pipes.Remove(pipe);
    }

    public GameObject nextPipe() {
        return pipes.Find(match: isNextPipe);
    }

    private bool isNextPipe(GameObject pipe)
    {
        return pipe.transform.position.x > transform.position.x;
    }
}
