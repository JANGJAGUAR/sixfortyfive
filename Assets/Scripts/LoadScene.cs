using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public float time = 0.0f;
    public float maxTime = 1.0f;
    public int count = 0;

    public TMP_Text loadText;
    public GameObject loadCard;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneName = GameManager.Instance.sceneName;
        StartCoroutine(LoadScenes(sceneName));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        loadCard.transform.Rotate(new Vector3(0, 5, 0));
        if (count <= 3)
        {
            loadText.text += ".";
            count++;
        }
        else
        {
            loadText.text = "Loading";
            count = 0;
        }
    }

    IEnumerator LoadScenes(string name)
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(name);
        op.allowSceneActivation = false;
        yield return new WaitForSecondsRealtime(1.0f);
        op.allowSceneActivation = true;
    }
}
