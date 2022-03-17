using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    Player player;
    void Update()
    {
        player = FindObjectOfType<Player>();
        if(player == null)
        {
            Invoke("ReloadScene", 1f);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(2);
    }
}
