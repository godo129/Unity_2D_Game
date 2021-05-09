using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{

    GameObject player;
    GameObject director;
    public Text Point;
    public int scorePoint = 0;
    void Awake()
    {
        Point = GameObject.Find("Point").GetComponent<Text>();
        Point.text = "0 POINT";

    }
    // GameObject director;
    // Start is called before the first frame update
    void Start()
    {
      //  this.director = GameObject.Find("GameDirector");
        this.player = GameObject.Find("cat");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 p1 = transform.position;
       // Vector2 p2 = this.player.transform.position;
       // Vector2 dir = p1 - p2;
       // float d = dir.magnitude;
       // float r1 = 0.35f; //코인 반경
       // float r2 = 0.7f; //고양이 반경
       // if (d < r1 + r2)
        //{  //충돌하면 코인 소멸
           // this.director.GetComponent<GameDirector>().Getcoin();
          //  Destroy(gameObject);
        //}


    }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌!");
            Destroy(gameObject);
            
        }
        
    }
     

}
