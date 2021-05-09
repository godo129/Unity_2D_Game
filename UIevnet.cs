using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIevnet : MonoBehaviour
{
    private bool pauseOn = false;
    private GameObject normalPanel;
    private GameObject pausePanel;
    private GameObject overPanel;
    int bestScorePoint;
    public Text BestScoreTx;
    public Text NowScoreTx;
    public int scorePoint ;
    public Text ScoreTItle;

    void Start()
    {
       
        
        bestScorePoint = PlayerPrefs.GetInt("BestScore"); // 시작시 베스트 스코어 얻어와서 대기
        // 현재 스   코어 얻어와서 대기 
        normalPanel = GameObject.Find("Canvas").transform.Find("NormalUI").gameObject;
        pausePanel = GameObject.Find("Canvas").transform.Find("PauseUI").gameObject;
        overPanel = GameObject.Find("Canvas").transform.Find("OverUI").gameObject;
        NowScoreTx = overPanel.transform.Find("NowScoreTx").GetComponent<Text>();
        BestScoreTx = overPanel.transform.Find("BestScoreTx").GetComponent<Text>();
        ScoreTItle = overPanel.transform.Find("ScoreTitle").GetComponent<Text>();

    }
    public void ActivePauseBt()
    {// 일시 정지 버튼을 눌렀을 때 처리.
        if(!pauseOn)
        { // 일시정지 중이 아니면 일시정지
            Time.timeScale = 0; // 시간 흐름 비율 0으로. 
            pausePanel.SetActive(true);
            normalPanel.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<CatController>().FreezeCat();
          
   

        }
        else
        {//일시정지 중이면 해제
            Time.timeScale = 1.0f; //시간 흐름 비율1로 .
            pausePanel.SetActive(false);
            normalPanel.SetActive(true);
        }
        pauseOn = !pauseOn; //불값 반전
    }

    public void RetryBT()
    {
        Debug.Log("게임 재시작");
        Time.timeScale=1.0f;//초기 상태로 돌려줌.
        SceneManager.LoadScene("first scene") ;//1번씬(현재씬) 다시 로드
    }
    public void QuitBT()
    {
        Debug.Log("게임 종료");
        Application.Quit();//게임 종료 - 어플 . 
    }
    public void SetGameOverUI()
    {

        scorePoint = PlayerPrefs.GetInt("Point");
        normalPanel.SetActive(false); 
        overPanel.SetActive(true);
        BestScoreTx.text = "(Best : " + bestScorePoint.ToString() + " Point)";
        NowScoreTx.text =  scorePoint.ToString() + " Point";
        ScoreTItle.text = scorePoint.ToString() + " Point";

    }

     /*IEnumerator PlusScoreRoutine()
    {
        
            Text nowScoreTx = overPanel.transform.FindChild("NowScoreTx").GetComponent<Text>();
            Text bestScoreTx = overPanel.transform.FindChild("BestScoreTx").GetComponent<Text>();
            bestScoreTx.text = "(BEST : " + PlayerPrefs.GetInt("BestScore").ToString("NO") + ")";//임시

        
    }*/
}
