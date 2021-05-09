using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        // 볼과 충돌이 되면 게임오버 
        if(col.CompareTag("Player"))
        {
            Debug.Log("충돌 : " + col.name);
            GameObject.FindWithTag("Player").GetComponent<CatController>().FreezeCat();
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().EndCountScore();
            GameObject.FindWithTag("GameController").GetComponent<UIevnet>().SetGameOverUI();
        }
        
    }
}
