using UnityEngine;
using UnityEngine.SceneManagement;

public class LSPreviewScene : MonoBehaviour
{
    public GUISkin skin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.Label(new Rect(0, 0, sw, sh), "Escape\nDungeon", "Preview");
    }
}
