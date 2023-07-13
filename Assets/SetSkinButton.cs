using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSkinButton : MonoBehaviour
{
    [SerializeField] int textureIndex;
    [SerializeField] Image[] image;

    public void SetTexture()
    {
        Globals.textureIndex = textureIndex;
    }

    public void Selector()
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (i == textureIndex)
            {
                image[i].color = Color.white;
            }
            else
            {
                image[i].color = Color.clear;
            }
        }
    }
}
