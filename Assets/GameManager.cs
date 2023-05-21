using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject UpWall;
    public GameObject DownWall;
    public GameObject Bonus;
    public GameObject[] Spawn;
    public float timer;
    public float timerBonus;
    public float timeBetweenSpawns;
    public float timeBetweenBonusSpawns;


    public float speedMultiplier;
    private float distance;
    public Text distanceUI;

    public GameObject _PlayerMove;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = _PlayerMove.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceUI.text = "Distance: " + distance.ToString("F2");
        speedMultiplier += Time.deltaTime * 0.1f;

        timer += Time.deltaTime;

        distance += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 2);
            if(randNum == 0)
            {
                Instantiate(DownWall, Spawn[randNum].transform.position, Quaternion.identity).GetComponent<Renderer>().sortingOrder = 100;
            }
            else
            {
                Instantiate(UpWall, Spawn[randNum].transform.position, Quaternion.identity).GetComponent<Renderer>().sortingOrder = 100;
            }
        }

        timerBonus += Time.deltaTime;
        
        if(timerBonus > timeBetweenBonusSpawns && playerMove.isBonusActive == false)
        {
            timerBonus = 0;
            int randNum = Random.Range(0, 2);
            Instantiate(Bonus, Spawn[0].transform.position, Quaternion.identity).GetComponent<Renderer>().sortingOrder = 101;

        }
    }
}
