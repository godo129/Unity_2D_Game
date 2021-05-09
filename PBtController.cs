using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PBtController : MonoBehaviour
{
    

   void Awake()
    {
        //bestScorePoint = PlayerPrefs.GetInt("BestScore");//시작시 베스트 스코어 얻어와 대기 
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivePauseBt()
    {

        Time.timeScale = 0; 
    }
}
