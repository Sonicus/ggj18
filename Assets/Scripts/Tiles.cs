using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour { 
    public float x = 1.0F;
    public float y = 1.0F;
    public string texture = "";
    public Renderer rend;
    void Start() {
        rend = GetComponent<Renderer>();
        rend.material.SetTextureScale(texture, new Vector2(x, y));
    }
    void Update() {
    }
}