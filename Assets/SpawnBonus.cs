using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private GameManager gm;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6)
        {
            Destroy(gameObject);
        }
        //rb.velocity = Vector2.left * (speed + gm.speedMultiplier);
        Debug.Log(transform.position.y.ToString());


        if (transform.position.y <= -3.55)
        {
            Debug.Log("góra");
            rb.velocity = new Vector2(-1, 1).normalized * (speed + gm.speedMultiplier);
        }

        if (transform.position.y >= -0.95f)
        {
            Debug.Log("Dó³");
            rb.velocity = new Vector2(-1, -1).normalized * (speed + gm.speedMultiplier);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}
