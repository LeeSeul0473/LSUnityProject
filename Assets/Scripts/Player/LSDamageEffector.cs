using System.Collections;
using UnityEngine;

public class LSDamageEffector : MonoBehaviour
{
    private bool effectFlag;
    private Color originalColor;
    public GameObject CharacterMesh1;
    public GameObject CharacterMesh2;


    void Start()
    {
        originalColor = CharacterMesh1.GetComponent<Renderer>().material.color;
        originalColor = CharacterMesh2.GetComponent<Renderer>().material.color;
        effectFlag = false;
    }


    void Update()
    {
        if (effectFlag)
        {
            CharacterMesh1.GetComponent<Renderer>().material.color = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
            CharacterMesh2.GetComponent<Renderer>().material.color = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
        }
    }


    IEnumerator Wait(float time)
    {
        effectFlag = true;
        yield return new WaitForSeconds(time);
        effectFlag = false;
        CharacterMesh1.GetComponent<Renderer>().material.color = originalColor;
        CharacterMesh2.GetComponent<Renderer>().material.color = originalColor;
    }

    void ApplyDamage(int amount)
    {
        StartCoroutine(Wait(0.3f));
    }
}
