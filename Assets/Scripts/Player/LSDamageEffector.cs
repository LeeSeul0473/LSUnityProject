using System.Collections;
using UnityEngine;

public class LSDamageEffector : MonoBehaviour
{
    private bool effectFlag;
    private Color originalColor;
    public GameObject CharacterMesh;


    void Start()
    {
        originalColor = CharacterMesh.GetComponent<Renderer>().material.color;
        effectFlag = false;
    }


    void Update()
    {
        if (effectFlag)
        {
            CharacterMesh.GetComponent<Renderer>().material.color = Color.red * Mathf.Abs(Mathf.Sin(60.0f * Time.time));
        }
    }


    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;
        CharacterMesh.GetComponent<Renderer>().material.color = originalColor;
    }

    void ApplyDamage(int amount)
    {
        StartCoroutine(Wait(0.3f));
    }
}
