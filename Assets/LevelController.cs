using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    [SerializeField] Texture[] textures;
    [SerializeField] TextMeshProUGUI itemsText;

    int totalItemCount = 0;
    int itemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
