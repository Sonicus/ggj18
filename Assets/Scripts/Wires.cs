using UnityEngine;
using System.Collections;

public class Wires : MonoBehaviour {
    public float scrollSpeed = 1.0F;
    public string texture = "";
    public Renderer rend;
    void Start() {
        rend = GetComponent<Renderer>();
    }
    void Update() {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset(texture, new Vector2(offset, 0));
    }
}