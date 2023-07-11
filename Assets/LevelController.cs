using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    [SerializeField] Texture[] textures;
    [SerializeField] TextMeshProUGUI itemsText;
    [SerializeField] TextMeshProUGUI timeText;

    int totalItemCount = 0;
    int itemCount = 0;
    float ttime;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "0";
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
        itemCount--;
        UpdateItemText();
        if (itemCount == 0)
        {
            // done
        }
    }

    // Update is called once per frame
    void Update()
    {
        ttime = Time.time;
        timeText.text = ttime.ToString("F2");
    }
}
