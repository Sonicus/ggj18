using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    List<IEnemy> enemies;
    Text deadText;
    Text resetText;
    Image blackOfDeath;
    AudioSource youDiedSound;
    AudioSource victorySound;
    FirstPersonController FPSController;
    bool gameLost;
    public int nextSceneIndex;

    // Use this for initialization
    void Start()
    {
        gameLost = false;
        deadText = GameObject.Find("GameLostText").GetComponent<Text>();
        deadText.canvasRenderer.SetAlpha(0.0f);
        resetText = GameObject.Find("ResetText").GetComponent<Text>();
        resetText.canvasRenderer.SetAlpha(0.0f);
        blackOfDeath = GameObject.Find("BlackOfDeath").GetComponent<Image>();
        blackOfDeath.canvasRenderer.SetAlpha(1.0f);
        blackOfDeath.CrossFadeAlpha(0.0f, 0.5f, true);
        youDiedSound = GameObject.Find("YouDiedSound").GetComponent<AudioSource>();
        victorySound = GameObject.Find("VictorySound").GetComponent<AudioSource>();
        FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>(); ;

        var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<IEnemy>();
        foreach (GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.GetComponentInChildren<IEnemy>());
        }
    }

    public void NextLevel()
    {
        victorySound.enabled = true;
        blackOfDeath.CrossFadeAlpha(1.0f, 1.0f, true);
        Invoke("LoadNextLevel", 1.0f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void EndGame()
    {
        print("Ending");
        FPSController.dead = true;
        gameLost = true;
        youDiedSound.enabled = true;
        blackOfDeath.CrossFadeAlpha(1.0f, 2.0f, true);
        Invoke("ShowDeathText", 2.0f);
    }

    private void ShowDeathText()
    {
        deadText.CrossFadeAlpha(1.0f, 4.0f, true);
        Invoke("ShowResetText", 4.0f);
    }

    private void ShowResetText()
    {
        resetText.CrossFadeAlpha(1.0f, 1.0f, true);
    }

    private void CheckForReset()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLost)
        {
            CheckForReset();
        }
    }
}

