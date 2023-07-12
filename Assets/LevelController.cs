using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    [SerializeField] Texture[] textures;
    [SerializeField] TextMeshProUGUI itemsText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI bestText;

    [SerializeField] AudioSource itemSource;
    [SerializeField] AudioClip itemClip;

    int totalItemCount = 0;
    public int itemCount = 0;
    public float ttime;
    float bestTime;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "0";
        bestText.color = Color.red;

        playerMaterial.mainTexture = textures[Globals.textureIndex];

        foreach (GameObject itemGo in GameObject.FindGameObjectsWithTag("Item")) {
            Item item = itemGo.GetComponent<Item>();
            item.SetLevelController(this);
            itemCount++;
            totalItemCount++;
        }
        UpdateItemText();
    }

    void UpdateItemText()
    {
        itemsText.text = $"Collected items: {totalItemCount - itemCount}/{totalItemCount}";
    }

    public void OnItemCollected()
    {
        itemSource.PlayOneShot(itemClip);
        itemCount--;
        UpdateItemText();
        if (itemCount == 0)
        {
            itemsText.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ttime = Time.timeSinceLevelLoad;
        bestTime = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        timeText.text = ttime.ToString("F2") + " ";
        if (bestTime != 0) 
        {
            bestText.text = " " + bestTime.ToString("F2");
        }
        else
        {
            bestText.text = "";
        }
    }
}
