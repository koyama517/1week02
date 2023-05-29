using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWay : MonoBehaviour
{

    public bool isAttack;

    public float count; 
    // Start is called before the first frame update
    void Start()
    {
        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isAttack)
        {
            count += Time.deltaTime;
        }
        if (count > 1) 
        {
            isAttack = false;
        }

        //Debug.Log(isAttack);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemyScript;
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
            {
                enemyScript = enemy.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    if (isAttack)
                    {
                        if (!enemyScript.isHit)
                        {
                            enemyScript.Damage();
                        }
                    }
                }
            }
        }
    }
}
