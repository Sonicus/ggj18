using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    List<IEnemy> enemies;
    Text deadText;
    Image blackOfDeath;
    AudioSource youDiedSound;
    FirstPersonController FPSController;
    bool gameLost;

	// Use this for initialization
	void Start () {
        gameLost = false;
        deadText = GameObject.Find("GameLostText").GetComponent<Text>();
        deadText.canvasRenderer.SetAlpha(0.0f);
        blackOfDeath = GameObject.Find("BlackOfDeath").GetComponent<Image>();
        blackOfDeath.canvasRenderer.SetAlpha(0.0f);
        youDiedSound = GameObject.Find("YouDiedSound").GetComponent<AudioSource>();
        FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>(); ;

        var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<IEnemy>();
        foreach(GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.GetComponentInChildren<IEnemy>());
        }
	}

    private void EndGame()
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
    }
	
	// Update is called once per frame
	void Update () {
        foreach(IEnemy enemy in enemies)
        {
            if (enemy.CheckForDetection() && !gameLost)
            {
                EndGame();
            }
        }
	}
}
