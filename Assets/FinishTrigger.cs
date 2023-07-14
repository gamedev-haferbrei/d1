using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] LevelController lvlctrl;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip finishClip;

    bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && lvlctrl.itemCount == 0)
        {
            if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name) > lvlctrl.ttime || PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name) == 0)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, lvlctrl.ttime); 
            } 
            if (firstTime)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(finishClip);
                firstTime = false;
            }
            lvlctrl.hasFinished = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
