using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeBtn : MonoBehaviour
{
    public Button button;
    public string sceneName;

    public bool reset = false;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void OnButtonClick()
    {
        SoundManager.Instance.PlayBtnClickSound();
        if (reset)
        {
            GameManager.Instance.finalScore = 0;
        }

        if (sceneName == "StoryHowTo")
        {
            SceneManager.LoadScene("StoryHowTo");
        }
        else if (sceneName == "Quit")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            GameManager.Instance.ChangeScene(sceneName);
        }
       
    }
}
