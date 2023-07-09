using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, ITriggerable
{
    Vector3 startPos;
    [SerializeField] Transform endPos;
    [SerializeField] float travelTime;
    [SerializeField] float waitTime;
    Rigidbody[] rbs;
    Vector3[] positionOffsets;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rbs = GetComponentsInChildren<Rigidbody>();

        positionOffsets = new Vector3[rbs.Length];
        for (int i = 0; i < rbs.Length; i++)
        {
            positionOffsets[i] = rbs[i].position - startPos;
        }
    }

    void ITriggerable.Trigger()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        bool backwards = false;
        while (true)
        {
            float timeElapsed = 0f;
            while (timeElapsed < travelTime)
            {
                timeElapsed += Time.deltaTime;
                float ratio = timeElapsed / travelTime;
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].MovePosition(Vector3.Lerp(startPos, endPos.position, backwards ? 1 - ratio : ratio) + positionOffsets[i]);
                }
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
            backwards = !backwards;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
