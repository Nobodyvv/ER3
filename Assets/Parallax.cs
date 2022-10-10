using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject player;
    Renderer rend;

    float playerStartPos;
    public float speed = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player");
        rend = GetComponent<Renderer>();
        playerStartPos = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - playerStartPos) * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
    }
}
