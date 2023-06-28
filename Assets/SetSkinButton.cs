using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkinButton : MonoBehaviour
{
    [SerializeField] int textureIndex;

    public void SetTexture()
    {
        Globals.textureIndex = textureIndex;
    }
}
