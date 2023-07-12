using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour, ITriggerable
{
    Transform[] ts;

    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponentsInChildren<Transform>(includeInactive: true);
    }

    void ITriggerable.Trigger()
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        foreach (Transform t in ts)
        {
            if (t.name.Equals("block"))
            {
                t.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f); 
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
