using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    [SerializeField] Texture[] textures;

    int itemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMaterial.mainTexture = textures[Globals.textureIndex];

        foreach (GameObject itemGo in GameObject.FindGameObjectsWithTag("Item")) {
            Item item = itemGo.GetComponent<Item>();
            item.SetLevelController(this);
            itemCount++;
        }
    }

    public void OnItemCollected()
    {
        itemCount--;
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
