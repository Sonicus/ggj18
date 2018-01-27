using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVArea : MonoBehaviour {
    Transform parentBody;
    bool seenPlayer;

	// Use this for initialization
	void Start () {
        parentBody = GetComponentInParent<Transform>();
        seenPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider collider)
    {
        RaycastHit hit;
        var direction = collider.transform.position - parentBody.position;
        if(Physics.Raycast(parentBody.position, direction, out hit, 9999f)){
            if(hit.collider.gameObject.tag == "Player")
            {
                print("Seen");
            }
        }
    }
}
