using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void loadGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
}
