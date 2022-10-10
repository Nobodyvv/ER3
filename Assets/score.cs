using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public GameObject player;
    public float scorea;
    public GameObject scoree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //your score == your player possition on the x axsis
        scorea = player.transform.localPosition.x;
        scoree = (scorea.ToString(0));

    }
}
