using System.Collections;
using UnityEngine;

public class LSActorGenerator : MonoBehaviour
{
    public float intervalMin = 1.0f;
    public float intervalMax = 3.0f;
    public GameObject keyPrefab;
    public GameObject ghostPrefab;

    private Coroutine generateCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator GhostGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));

            float currentX = this.transform.position.x;
            float currentZ = this.transform.position.z;
            float spawnLocationX = Random.Range(currentX-4.0f, currentX + 4.0f);
            float spawnLocationZ = Random.Range(currentZ-4.0f, currentZ + 4.0f);
            Vector3 spawnPosition = new Vector3(spawnLocationX, 1f, spawnLocationZ);
            Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void KeyGenerate()
    {
        float currentX = this.transform.position.x;
        float currentZ = this.transform.position.z;
        float spawnLocationX = Random.Range(currentX - 4.0f, currentX + 4.0f);
        float spawnLocationZ = Random.Range(currentZ - 4.0f, currentZ + 4.0f);
        Vector3 spawnPosition = new Vector3(spawnLocationX, 1f, spawnLocationZ);
        Instantiate(keyPrefab, spawnPosition, Quaternion.identity);
    }

    void StartGenerate()
    {
        generateCoroutine = StartCoroutine(GhostGenerate());
    }

    void StopGenerate()
    {
        if (generateCoroutine != null)
        {
            StopCoroutine(generateCoroutine);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
