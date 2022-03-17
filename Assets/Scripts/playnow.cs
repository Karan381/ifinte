using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playnow : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void onPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void onQuit()
    {
        Application.Quit();
    }
}
