using System.Collections;
using UnityEngine;

public class LSActorGenerator : MonoBehaviour
{
    public float intervalMin = 1.0f;
    public float intervalMax = 3.0f;
    public GameObject keyPrefab;
    public GameObject ghostPrefab1;
    public GameObject ghostPrefab2;
    public GameObject ghostPrefab3;
    public GameObject ghostPrefab4;
    public GameObject ghostPrefab5;

    private Coroutine generateCoroutine;
    private GameObject ghostPrefab;

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
            if (ghostPrefab != null)
            {
                Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void KeyGenerate()
    {
        float currentX = this.transform.position.x;
        float currentZ = this.transform.position.z;
        float spawnLocationX = Random.Range(currentX - 3.5f, currentX + 3.5f);
        float spawnLocationZ = Random.Range(currentZ - 3.5f, currentZ + 3.5f);
        Vector3 spawnPosition = new Vector3(spawnLocationX, 1f, spawnLocationZ);
        Instantiate(keyPrefab, spawnPosition, Quaternion.identity);
    }

    void StartGenerate(int inLevel)
    {
        Debug.Log("StartGenerate started : "+ inLevel);
        switch (inLevel)
        {
            case 1:
                ghostPrefab = ghostPrefab1;
                break;
            case 2:
                ghostPrefab = ghostPrefab2;
                break;
            case 3:
                ghostPrefab = ghostPrefab3;
                break;
            case 4:
                ghostPrefab = ghostPrefab4;
                break;
            case 5:
                ghostPrefab = ghostPrefab5;
                break;
            default:
                break;
        }

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
