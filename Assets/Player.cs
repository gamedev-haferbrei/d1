using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float godModeSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float customGravity;
    [SerializeField] string levelName;

    [SerializeField] AudioSource jumpSource;
    [SerializeField] AudioClip jumpClip;

    [SerializeField] GameObject dustParticlesPrefab;

    int availableJumps = 2;

    bool godMode;
    InputActions controls;
    Rigidbody rb;

    Vector3 dir;
    Vector3 startPos;

    private void Awake()
    {
        controls = new InputActions();
         
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.name);
        startPos = rb.position;
    }

    private void OnEnable()
    {
        controls.Player.Move.performed += (ctx) =>
        {
            Vector2 axes = ctx.ReadValue<Vector2>();
            dir = new Vector3(axes.x, 0, axes.y);
        };
        controls.Player.Jump.performed += (ctx) =>
        {
            if (availableJumps > 0)
            {
                jumpSource.PlayOneShot(jumpClip);
                rb.AddForce(jumpForce * Vector3.up);
                availableJumps--;
            }
        };
        controls.Player.GodModeMove.performed += (ctx) =>
        {
            dir = ctx.ReadValue<Vector3>();
        };
        controls.Player.GodModeToggle.performed += (ctx) =>
        {
            if (godMode) DisableGodMode();
            else EnableGodMode();
        };
        controls.Player.Restart.performed += (ctx) =>
        {
            SceneManager.LoadScene("Menu");
        };
        controls.Enable();
    }

    private void FixedUpdate()
    {
        if (godMode)
        {
            rb.position += godModeSpeed * dir;
        } else
        {
            rb.AddForce(speed * dir + customGravity * Vector3.down);
        }
    }

    void EnableGodMode()
    {
        godMode = true;
        rb.isKinematic = true;
    }

    void DisableGodMode()
    {
        godMode = false;
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal.y > 0.3) availableJumps = 2;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (godMode || dir.magnitude < 0.1) return;
        ContactPoint contact = collision.GetContact(0);
        if (contact.normal.y > 0.3) Instantiate(dustParticlesPrefab, contact.point, Quaternion.Euler(-90f, 0, 0));
    }

    /*void Death()
    {
        if (Input.GetKeyDown("K"))
        {
            Debug.Log("position!");
            //rb.position = startPos;
            /*GameObject magic1f = GameObject.FindWithTag("Magic1");        rb.position.y <= -1f
            GameObject magic2f = GameObject.FindWithTag("Magic2");
            GameObject magic3f = GameObject.FindWithTag("Magic3");
            Switch magic1 = magic1f.GetComponent<Switch>();
            Switch magic2 = magic2f.GetComponent<Switch>();
            Switch magic3 = magic3f.GetComponent<Switch>();
            magic1.pressed = false;
            magic2.pressed = false;
            magic3.pressed = false;
            SceneManager.LoadScene(levelName);
        }
    }*/
    //}
    //}
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("k"))
        {
            Debug.Log("position!");
            //rb.position = startPos;
            GameObject magic1f = GameObject.FindWithTag("Magic1");        rb.position.y <= -1f
            GameObject magic2f = GameObject.FindWithTag("Magic2");
            GameObject magic3f = GameObject.FindWithTag("Magic3");
            Switch magic1 = magic1f.GetComponent<Switch>();
            Switch magic2 = magic2f.GetComponent<Switch>();
            Switch magic3 = magic3f.GetComponent<Switch>();
            magic1.pressed = false;
            magic2.pressed = false;
            magic3.pressed = false;
            SceneManager.LoadScene(levelName);
        }
    
        */
    }
}
