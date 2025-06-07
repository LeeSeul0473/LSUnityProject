using UnityEngine;
using UnityEngine.SceneManagement;

public class LSStartScene : MonoBehaviour
{
    public GUISkin skin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.Label(new Rect(0, sh / 4, sw, sh / 4), "Escape Dungeon", "Title");
        GUI.Label(new Rect(0, sh / 2, sw, sh / 4), "Press Space Bar to Start", "Title");
    }
}
