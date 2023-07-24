using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reindeerMove : MonoBehaviour
{
    Transform tr;
    private Animator animator;
    public float moveSpeed = 1.0f;
    private float h = 0.0f;
    private float v = 0.0f;

    bool IsDie = false;
    public enum ReindeerState { idle, walk, die };
    public ReindeerState reindeerState = ReindeerState.idle;

    public AudioSource reindeeraudio;
    public AudioClip walkRSfx;

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckReindeerState());
        StartCoroutine(this.ReindeerAction());

        reindeeraudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

    }

    IEnumerator CheckReindeerState()
    {
        while (!IsDie)
        {
            yield return new WaitForSeconds(0.2f);

            if (Mathf.Abs(h - 0.0f) > 0.01) 
            { 
                reindeerState = ReindeerState.walk;
                reindeeraudio.PlayOneShot(walkRSfx);
            }
            else if (Mathf.Abs(v - 0.0f) > 0.01)
            {
                reindeerState = ReindeerState.walk;
                reindeeraudio.PlayOneShot(walkRSfx);
            }
            else reindeerState = ReindeerState.idle;
        }
    }

    IEnumerator ReindeerAction()
    {
        while (!IsDie)
        {
            switch (reindeerState)
            {
                case ReindeerState.idle:
                    animator.SetBool("IsIdle", true);
                    animator.SetBool("isWalk", false);
                    break;
                case ReindeerState.walk:
                    animator.SetBool("IsIdle", false);
                    animator.SetBool("isWalk", true);
                    break;
            }
            yield return null;
        }
    }
}
