using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Wall;
    public GameObject[] Spawn;
    public float timer;
    public float timeBetweenSpawns;


    public float speedMultiplier;
    private float distance;
    public Text distanceUI;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Instantiate(Wall, Spawn[randNum].transform.position, Quaternion.identity);
        }
    }
}
