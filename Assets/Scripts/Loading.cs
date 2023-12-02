using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider loading;
    public float seconds = 5f, time;

    void Start()
    {
        Invoke("LoadGame", seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(time < seconds)
        {
            time += Time.deltaTime;
            loading.value = time / seconds;
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}
