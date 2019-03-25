using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Monster_Movement : MonoBehaviour
{
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
    }

    void run()
    {
        movement = new Vector2(moveHorizontal + speed, 0);
        rb.velocity = movement;
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
