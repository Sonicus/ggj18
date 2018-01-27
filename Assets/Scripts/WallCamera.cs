using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCamera : MonoBehaviour, IEnemy {

    public float turnAngle = 45.0f;
    public float turnSpeed = 0.25f;
    private float turnedAngle = 0.0f;
    FOVArea fovArea;

    public bool CheckForDetection()
    {
        return fovArea.seenPlayer;
    }

	// Use this for initialization
	void Start () {
        fovArea = GetComponentInChildren<FOVArea>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(turnedAngle) > turnAngle)
        {
            turnSpeed *= -1;
        }
        this.transform.Rotate(new Vector3(0, turnSpeed, 0));
        turnedAngle += turnSpeed;
	}

}
