using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aaa : MonoBehaviour
{
    public int scorePoint = 0;
    private Text scoreTx;

    void Awake()
    {
        scoreTx = GameObject.Find("NormalUI").transform.Find("scoreTx").GetComponent<Text>();
        scoreTx.text = "SCORE : 0";
       
    }
    public void PlusScore(int plusPoint)
    {
        scorePoint += plusPoint;
        scoreTx.text = "SCORE : " + scorePoint.ToString("NO"); 
    }

}
