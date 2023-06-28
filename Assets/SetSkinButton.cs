using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkinButton : MonoBehaviour
{
    [SerializeField] Texture texture;

    void SetTexture()
    {
        Globals.playerTexture = texture;
    }
}
