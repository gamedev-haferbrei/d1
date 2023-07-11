using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Material onMaterial;
    [SerializeField] Component triggers;
    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!pressed && collision.gameObject.CompareTag("Player"))
        {
            if (triggers is ITriggerable) ((ITriggerable)triggers).Trigger();
            pressed = true;
            GetComponent<Renderer>().material = onMaterial;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
