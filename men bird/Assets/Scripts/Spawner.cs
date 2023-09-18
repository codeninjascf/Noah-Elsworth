using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Start function repeating every 4 seconds
        InvokeRepeating("InstantiateObjects", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Position for the gameobjects
        transform.position = new Vector3(5, Random.Range(-height, height), 0);
    }
}
//Object that we will attach to the script for spawning object
[Header("Spikes Object for controlling the game")]
public GameObject spikes;
//Height position of the spikes
[Header("Default Height")]
public float height;

//InstantiateObjects Function
void InsantiateObjects()
{
    //Spawn object by position and rotation
    Insantiate(spikes, transform.position, transform.rotation);
}