using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedEnemies;

    private int randomIndex;
    private int randomSide;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){

        while(true){
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemies = Instantiate(enemyReference[randomIndex]);

            if(randomSide == 0){
                spawnedEnemies.transform.position = leftPos.position;
                spawnedEnemies.GetComponent<Enemy>().movement = Random.Range(4, 10);
                spawnedEnemies.transform.localScale = new Vector3(-5f, 5f, 1f);
            }else{
                spawnedEnemies.transform.position = rightPos.position;
                spawnedEnemies.GetComponent<Enemy>().movement = -Random.Range(4, 10);
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
