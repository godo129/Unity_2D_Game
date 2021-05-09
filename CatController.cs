using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{

    public int bestScorePoint; // 최고점 일시 저장 
    Rigidbody2D rigid2D;
    Animator animator;
    // float threshold = 0.2f;
    float jumpForce = 400.0f;
    float walkForce = 20.0f;
    float maxWalkSpeed = 2.0f;
    float CatPosition;
    //GameObject director;
    int key = 0;

    bool freezeState = false; // 종료되고 freeze된 상태인지....


    public Text BPoint;
    public Text Point;
    public int scorePoint = 0;
    void Awake()
    {
        bestScorePoint = PlayerPrefs.GetInt("BestScore"); // 시작시 베스트 스코어 얻어와서 대기
        
       
        BPoint = GameObject.Find("BPoint").GetComponent<Text>();
        Point = GameObject.Find("Point").GetComponent<Text>();
        Point.text = "0 POINT";
        BPoint.text = "Best : 0 Point";

    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        //this.director = GameObject.Find("GameDirector");

    }


    
    // Update is called once per frame
    void Update()
    {
        BPoint.text = "(Best : " + bestScorePoint.ToString() + " Point)";
       
        // int Ykey = 0;
        if (scorePoint > bestScorePoint)// 기록 비교 
        {

            //신기록
            bestScorePoint = scorePoint;

            PlayerPrefs.SetInt("BestScore", bestScorePoint);
            PlayerPrefs.Save();


        }

        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }  // 점프 
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        // 좌우 이동 

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //플레이어 속도 

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //스피드제한 

        if (key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        } // 고양이 좌우 반전 

        //this.animator.speed = speedx / 2.0f; // 플레이어 속도에 맞춰 애니메이션 속도 바꿈        

        if (transform.position.y < -7.1f)
        {
            scorePoint = 0;
            PlayerPrefs.SetInt("Point", scorePoint);
            Debug.Log("골");
            GameObject.FindWithTag("Player").GetComponent<CatController>().FreezeCat();
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().EndCountScore();
            GameObject.FindWithTag("GameController").GetComponent<UIevnet>().SetGameOverUI();
        }  // 고양이가 타일에서 떨어짐 



    }
    public void PlusScore(int plusPoint)
    {
        scorePoint += plusPoint; // 받아온 만큼 점수 추가 
        Point.text = scorePoint.ToString("") + " Point";

        PlayerPrefs.SetInt("Point", scorePoint);
        
        

        if (scorePoint < 0) // 스코어가 0 이하이면 종료 
        {
            GameObject.FindWithTag("Player").GetComponent<CatController>().FreezeCat();
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().EndCountScore();
            GameObject.FindWithTag("GameController").GetComponent<UIevnet>().SetGameOverUI();
        }
        
        }
  
       

    
    public void text()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {


            PlusScore(100); // 코인 부딛히면 100점 추가 
        } else if (col.CompareTag("enemy"))
        {


            PlusScore(-40); // 적에 부딛히면 40점 감소 

        }

    }
    public void FreezeCat()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || transform.position.y < -5.7f) //걷고 있거나 점프하면 
        {
            maxWalkSpeed = -100.0f; // 걷기멈춤
            jumpForce = 0; // 뛰기 멈춤
            key = 0;

            // 고양이 좌우 반전 
            // 고양이 좌우 반전   //좌우 반전 x
            //멈춤
           

        }
        else
        {


        }
        freezeState = true;

    }

 

}
