using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject pointText;
    int point = 0;
    // Start is called before the first frame update

        public void GetCoin()
    {
        this.point += 100;
    }
    public void GetEnemy()
    {
        this.point -= 50;
    }

    void Start()
    {
        this.pointText = GameObject.Find("Point");
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.time -= Time.deltaTime;
        this.pointText.GetComponent<Text>().text = this.point.ToString()+" point";
    }
}
