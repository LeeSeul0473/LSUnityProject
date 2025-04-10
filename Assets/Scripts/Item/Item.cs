using UnityEngine;

public class Item : MonoBehaviour, TakeDamageInterface
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("데미지 함수 호출 : " + damage);
        Destroy(gameObject);
    }
}
