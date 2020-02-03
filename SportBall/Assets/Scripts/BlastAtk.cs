using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastAtk : MonoBehaviour
{
    public Player1Controller playerScript;

    public float BlastVel;

    public GameObject PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (playerScript.atkDir == 0)
        {
            transform.localScale = new Vector2(0.05f, 0.05f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //transform.localPosition = new Vector2(0, 0);
            transform.position = new Vector2(PlayerTarget.transform.position.x, PlayerTarget.transform.position.y);
        }
        else if (playerScript.atkDir == 3)
        {
            StartCoroutine(resetAtk());
            transform.localScale = new Vector2(0.5f, 1 + (playerScript.prepBlastVal / 5));
            BlastVel = 7.5f + (playerScript.prepBlastVal / 1.5f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(BlastVel, 0);
            //transform.position = new Vector2(transform.position.x + BlastVel, transform.position.y);
        }
        else if (playerScript.atkDir == 6)
        {
            StartCoroutine(resetAtk());
            transform.localScale = new Vector2(1f + (playerScript.prepBlastVal / 5), 0.5f);
            BlastVel = 7.5f + (playerScript.prepBlastVal / 1.5f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -BlastVel);
            //transform.position = new Vector2(transform.position.x, transform.position.y - BlastVel);
        }
        else if (playerScript.atkDir == 9)
        {
            StartCoroutine(resetAtk());
            transform.localScale = new Vector2(0.5f, 1 + (playerScript.prepBlastVal / 5));
            BlastVel = 7.5f + (playerScript.prepBlastVal / 1.5f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-BlastVel, 0);

//            transform.position = new Vector2(transform.position.x - BlastVel, transform.position.y);
        }
        else if (playerScript.atkDir == 12)
        {
            StartCoroutine(resetAtk());
            transform.localScale = new Vector2(1 + (playerScript.prepBlastVal / 5), 0.5f);
            BlastVel = 7.5f + (playerScript.prepBlastVal/ 1.5f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, BlastVel);

            //transform.position = new Vector2(transform.position.x , transform.position.y + BlastVel);
        }
    }

    public IEnumerator resetAtk()
    {
        yield return new WaitForSeconds(0.15f);
        playerScript.atkDir = 0;
        playerScript.hasAtkd = false;
        BlastVel = 7.5f;
        playerScript.prepBlastVal = 0;
    }
}
