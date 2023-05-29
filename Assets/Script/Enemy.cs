using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Vector2 dir;

    public bool isHit;

    public int hp;

    private float hitTimer;

    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x < -4.5 || transform.position.x > 4.5)
        {
            dir.x *= -1;
        }
        if (transform.position.y < -4.5 || transform.position.y > 4.5)
        {
            dir.y *= -1;
        }

        if (hp <= 0)
        {
            Destroy(this);
        }

        if (isHit)
        {
            if (hitTimer >= 1)
            {
                isHit = false;
            }
            else
            {
                hitTimer += Time.deltaTime;
            }
        }

    }

    public void Damage()
    {
        hp -= 1;
        isHit = true;
    }
}
