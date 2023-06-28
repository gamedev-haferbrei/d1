using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelButton : MonoBehaviour
{
    [SerializeField] string levelName;

    public void StartLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
