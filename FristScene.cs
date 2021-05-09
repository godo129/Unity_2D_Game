using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FristScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void StartBT()
    {
       
        SceneManager.LoadScene("first scene");//1번씬(현재씬) 다시 로드
    }

    public void QuitBT()
    {
        
        Application.Quit();//게임 종료 - 어플 . 
    }
    // Update is called once per frame
    void Update () {
		
	}
}
