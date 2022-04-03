using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private Rigidbody mycharacter;
    private int IsWalkingRight = 45;
    public Transform rayStart;
    private Animator anim;
    private GameManager game;
    public Text text;

    void Awake()
    {
        mycharacter = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        game = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!game.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gameStarted");
        }

        mycharacter.transform.position = transform.position + transform.forward * 2 * Time.deltaTime; 
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!game.gameStarted)
            return;
        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            if(transform.position.y <= -0.3)
                anim.SetTrigger("IsFalling");
            if (transform.position.y < -3)
                game.EndGame();
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsWalkingRight *= -1;
            transform.rotation = Quaternion.Euler(0, IsWalkingRight, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            game.IncreaseScore();
        }
    }
}
