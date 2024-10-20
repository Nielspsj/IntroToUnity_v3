using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();
    public List<Transform> spawnLocationsList = new List<Transform>();
    public GameObject enemyToSpawnGO;
    private int index;
    private int indexInOrder = 0;
    private Vector3 spawnPosition;

    public List<GameObject> pickupsList = new List<GameObject>();    
    private GameObject pickupToAdd;

    public List<string> StoryLines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Number of enemies in list: " + enemiesList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemy();
        }
        //SpawnEnemy();
        //SpawnAtLocations();
        SpawninOrder();

        if (Input.GetKeyDown(KeyCode.L))
        {
            PrintStoryLine();
        }
    }
    private void SpawnEnemy()
    { 
        if(enemiesList.Count > 0)
        {
            index = Random.Range(0, enemiesList.Count);
            spawnPosition = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
            GameObject enemyGO = Instantiate(enemiesList[index].gameObject, spawnPosition, enemiesList[index].gameObject.transform.rotation);
            enemiesList.RemoveAt(index);
        }
        else
        {
            Debug.Log("All enemies spawned!");
        }
    }
    private void AddPickup()
    {
        pickupsList.Add(pickupToAdd);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Pickup")
        {
            pickupToAdd = other.gameObject;
            AddPickup();
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<Renderer>().enabled = false;
            other.transform.position = new Vector3(1000, 0, 0);
        }
    }
    private void PrintStoryLine()
    {
        index = Random.Range(0, StoryLines.Count);
        Debug.Log("Storyline " + index + " : " + StoryLines[index]);
    }
    private void SpawnAtLocations()
    {
        if (spawnLocationsList.Count > 0)
        {            
            index = Random.Range(0, spawnLocationsList.Count);
            
            GameObject enemyGO = Instantiate(enemyToSpawnGO, spawnLocationsList[index].position, spawnLocationsList[index].rotation);
            Destroy(spawnLocationsList[index].gameObject);
            spawnLocationsList.RemoveAt(index);            
        }
        else
        {
            Debug.Log("All spawn locations used!");
        }
    }
    private void SpawninOrder()
    {
        if (spawnLocationsList.Count > indexInOrder)
        {            
            GameObject enemyGO = Instantiate(enemyToSpawnGO, spawnLocationsList[indexInOrder].position, spawnLocationsList[indexInOrder].rotation);
            Destroy(spawnLocationsList[indexInOrder].gameObject);
            spawnLocationsList.RemoveAt(indexInOrder);
            indexInOrder++;
        }
        else
        {
            Debug.Log("All spawn locations used!");
        }
    }
}
