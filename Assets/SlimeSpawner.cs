using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    public int numberOfSlimes = 5;
    public Vector2 mapSize = new Vector2(10,10);
    public List<GameObject> slimes = new List<GameObject>();

    public static SlimeSpawner instance;

    private void Awake() {
         instance = this;
    }

    void Start()
    {
        SpawnSlimes();
    }

    public void SpawnSlimes()
    {
      for(int i = 0; i < numberOfSlimes; i++)
        {
            // Generate random position within the map bounds
            Vector2 spawnPosition = new Vector2(Random.Range(-mapSize.x / 2, mapSize.x / 2), Random.Range(-mapSize.y / 2, mapSize.y / 2));

             GameObject slime = Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
             slimes.Add(slime);
        }
    }

    public void RemoveSlime(GameObject slimeToRemove) {
       slimes.Remove(slimeToRemove);

        if(slimes.Count == 0) {
            // All slimes are defeated, game end
            GameEnd();
        }
    }

    public void GameEnd() {
         print("You win!");
    }

}
