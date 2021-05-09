using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    GameObject pointText;
    int point = 0;
    // Start is called before the first frame update
    public void Getcoin()
    {
        this.point += 100; 
    }
    
    public void Getmonster()
    {
        this.point -= 50;
    }

    // Update is called once per frame
    void Start()
    {
        this.pointText = GameObject.Find("Point");
    }

    void Update()
    {
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " Point";
    }
    
}
