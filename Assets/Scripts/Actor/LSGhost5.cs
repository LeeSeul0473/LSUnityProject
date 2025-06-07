using UnityEngine;

public class LSGhost5 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_BaseColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
