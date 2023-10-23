using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public LogicScript logic;
    public float spawnRate = 4F;
    private float timer = 0;
    public float heigthOffset = 25;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {   
        if (!logic.isAlive)
            return;

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnPipe();
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heigthOffset;
        float highestPoint = transform.position.y + heigthOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
        logic.addPipe(pipe);
    }
}
