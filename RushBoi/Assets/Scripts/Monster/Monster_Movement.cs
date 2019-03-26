using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monster_Movement : MonoBehaviour
{

    public GameObject Player;
    public Text scoreText;
    public Text distanceText;

    float distance = 0;
    float score = 0;
    float first_pos;
    Tween tween;
    float moveHorizontal;
    public float speed;
    Vector2 movement;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        first_pos = transform.position.y;
             rb = GetComponent<Rigidbody2D>();
        StartCoroutine("fly");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        run();
        KillPlayer();
        addScore();
        distanceToEnemy();

        print(Player.transform.position.x);
        print(transform.position.x);
    }

    void run()
    {
        movement = new Vector2(moveHorizontal + speed, 0);
        rb.velocity = movement;
    }

    void KillPlayer()
    {
        if (Player.transform.position.x < transform.position.x || Player.transform.position.y < -5)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    void addScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    void distanceToEnemy()
    {
        distance = Mathf.Ceil(Player.transform.position.x - transform.position.x);


        distanceText.text = "Distance: " + distance +"M";
    }

    IEnumerator fly()
    {
        while (true)
        {
            tween = transform.DOMoveY(first_pos + 2f, 0.5f);
            yield return tween.WaitForCompletion();

            tween = transform.DOMoveY(first_pos, 0.5f);
            yield return tween.WaitForCompletion();

            yield return null;
        }
    }

}
