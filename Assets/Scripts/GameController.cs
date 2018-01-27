using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    List<IEnemy> enemies;

	// Use this for initialization
	void Start () {
        var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<IEnemy>();
        foreach(GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.GetComponentInChildren<IEnemy>());
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
