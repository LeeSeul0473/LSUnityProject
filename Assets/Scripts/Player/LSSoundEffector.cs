using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class LSSoundEffector : MonoBehaviour
{
    public AudioClip catchKey;
    public AudioClip damaged;
    public AudioClip killedGhost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CatchKey()
    {
        GetComponent<AudioSource>().PlayOneShot(catchKey);
    }

    void ApplyDamage(int amount)
    {
        GetComponent<AudioSource>().PlayOneShot(damaged);
    }

    void KilledGhost()
    {
        GetComponent<AudioSource>().PlayOneShot(killedGhost);
    }
}
