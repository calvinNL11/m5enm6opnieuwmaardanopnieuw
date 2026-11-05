using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTower();
        }
    }

    void SpawnTower()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-5f, 5f),
            -1.6f,
            Random.Range(-5f, 5f)
            );

        GameObject newTower = Instantiate(towerPrefab, randomPosition, Quaternion.identity);
    }
}