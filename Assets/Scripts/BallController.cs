using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int Score;
    Text ScoreUI;
    GameObject GameOver;
    Text txPemenang;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
        Score = 0;
        ScoreUI = GameObject.Find("Score").GetComponent<Text>();
        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Tepibawah")
        {
            Score += 10;
            TampilkanScore();
            if (Score == 100)
            {
                GameOver.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "You Win!";
                Destroy(gameObject);
                 return;
                 }
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized;
            rigid.AddForce(arah * force);
            
           
        }
        void ResetBall()
        {
            transform.localPosition = new Vector2(0, -4);
            rigid.velocity = new Vector2(0, 0);
        }
        if (coll.gameObject.name == "Player")
        {
             float sudut = (transform.position.x - coll.transform.position.x) * 4f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
           rigid.AddForce(arah * force * 2);
        }
    }
        void ResetBall()
        {
            transform.localPosition = new Vector2(0, 0);
            rigid.velocity = new Vector2(0, 0);
        }
    void TampilkanScore()
    {
        Debug.Log("Score;" + Score);
        ScoreUI.text = Score + "";
    }
}