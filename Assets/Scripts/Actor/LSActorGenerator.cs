using System.Collections;
using UnityEngine;

public class LSActorGenerator : MonoBehaviour
{
    public float IntervalMin = 0.5f;
    public float IntervalMax = 1.5f;
    public float KeyRate = 0.01f;
    public GameObject KeyPrefab;
    public GameObject SpikeBallPrefab;
    private bool isKeyGenerated = false;

    private Coroutine generateCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(IntervalMin, IntervalMax));

            GameObject prefab;
            if(!isKeyGenerated && Random.value < KeyRate)
            {
                Debug.Log("Key Generated");
                prefab = KeyPrefab;
                isKeyGenerated = true;
            }
            else
            {
                prefab = SpikeBallPrefab;
            }

            float currentX = this.transform.position.x;
            float currentZ = this.transform.position.z;
            float spawnLocationX = Random.Range(currentX-5.0f, currentX + 5.0f);
            float spawnLocationZ = Random.Range(currentZ-5.0f, currentZ + 5.0f);
            Vector3 spawnPosition = new Vector3(spawnLocationX, 1f, spawnLocationZ);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    void StartGenerate()
    {
        generateCoroutine = StartCoroutine(Generate());
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
