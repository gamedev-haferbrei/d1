using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingPlatform : MonoBehaviour, ITriggerable
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    void ITriggerable.Trigger() {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
