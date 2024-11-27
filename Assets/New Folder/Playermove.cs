using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float speedjump;
    private Rigidbody2D player;
    private bool isongroud;
    public Transform groundcheck;
    public float groundradious;
    public LayerMask ground;
    private bool iswallslide;
    [SerializeField] public float wallslidespeed;
    public Transform wallcheck;
    public LayerMask wallleyer;
    private bool iswalljump;
    private float walljumpdeer;
    private float walljumptime = 0.2f;
    private float walljumpcount;
    private float wallduration = 0.4f;
    private Vector2 walljumppower = new Vector2(3f, 7f);
    private bool isfaceright = true;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!iswalljump)
        {
            player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);
        }
        isongroud = Physics2D.OverlapCircle(groundcheck.position, groundradious, ground);
        if (Input.GetButtonDown("Jump") && isongroud == true) 
        {
            player.velocity = new Vector2(player.velocity.x, speedjump);
        }
        wallslideb();
        
        walljump();
        if (!iswalljump)
        {
            flip();
        }

    }
    private void flip()
    {
        if(isfaceright && Input.GetAxis("Horizontal") < 0f || !isfaceright && Input.GetAxis("Horizontal") > 0f)
        {
            isfaceright = !isfaceright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;  
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "lvlchange1")
        {
            SceneManager.LoadScene("lvl2");

        }
        if (collision.transform.tag == "lvlchange2")
        {
            SceneManager.LoadScene("lvl3");

        }
    }
    private bool iswalled()
    {
        return Physics2D.OverlapCircle(wallcheck.position, 0.2f, wallleyer);
    }
    private void wallslideb()
    {
        if(iswalled() && !isongroud == true && Input.GetAxis("Horizontal") != 0)
        {
            iswallslide = true;
            player.velocity = new Vector2(player.velocity.x, Mathf.Clamp(player.velocity.y, -wallslidespeed, float.MaxValue));
        }
        else
        {
            iswallslide = false;
        }
    }
    private void stopwalljump()
    {
        iswalljump = false;
    }
    private void walljump()
    {
        if (iswallslide)
        {
            iswalljump = false;
            walljumpdeer = -transform.localScale.x;
            walljumpcount = walljumptime;
            CancelInvoke(nameof(stopwalljump));
        }
        else
        {
            walljumpcount -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && walljumpcount > 0f)
        {
            iswalljump = true;
            player.velocity = new Vector2(walljumpdeer * walljumppower.x, walljumppower.y);
            walljumpcount = 0f;
            if (transform.localScale.x != walljumpdeer)
            {
                isfaceright = !isfaceright;
                Vector3 localscale = transform.localScale;
                localscale.x *= -1f;
                transform.localScale = localscale;
            }
            Invoke(nameof(stopwalljump), wallduration);
        }
    }
}
