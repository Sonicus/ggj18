﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVArea : MonoBehaviour {
    Transform parentBody;
    GameController gameController;

	// Use this for initialization
	void Start () {
        parentBody = transform.parent;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider collider)
    {
        RaycastHit hit;
        var direction = collider.transform.position - parentBody.position;
        int layerMask = ~(1 << 9);
        if(Physics.Raycast(parentBody.position, direction, out hit, 9999f, layerMask)){
            if(hit.collider.gameObject.tag == "Player" && !gameController.gameLost)
            {
                gameController.EndGame();
            }
        }
    }
}
