using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMove : MonoBehaviour
{
    public GameObject giftPrefab;
    Transform tr;
    private Animator animator;
    public float moveSpeed = 1.0f;
    private float h = 0.0f;
    private float v = 0.0f;
    private float j = 0.0f;

    public AudioSource santaaudio;
    public AudioClip walkSfx, jumpSfx, giftSfx;

    bool IsDie = false;
    public enum SantaState { idle, walk, jump, die };
    public SantaState santaState = SantaState.idle;

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckSantaState());
        StartCoroutine(this.SantaAction());

        santaaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(giftPrefab, tr.position, tr.rotation);
            santaaudio.PlayOneShot(giftSfx);
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        j = Input.GetAxis("Jump");


        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir * Time.deltaTime * moveSpeed);

    }

    IEnumerator CheckSantaState()
    {
        while (!IsDie)
        {
            yield return new WaitForSeconds(0.2f);

            if (Mathf.Abs(h - 0.0f) > 0.01)
            {
                santaState = SantaState.walk;
                santaaudio.PlayOneShot(walkSfx);
            }
            else if (Mathf.Abs(v - 0.0f) > 0.01)
            {
                santaState = SantaState.walk;
                santaaudio.PlayOneShot(walkSfx);
            }
            else if (Mathf.Abs(j - 0.0f) > 0.01)
            {
                santaState = SantaState.jump;
                santaaudio.PlayOneShot(jumpSfx);
            }
            else santaState = SantaState.idle;
        }
    }

    IEnumerator SantaAction()
    {
        while (!IsDie)
        {
            switch (santaState)
            {
                case SantaState.idle:
                    animator.SetBool("IsIdle", true);
                    animator.SetBool("IsWalk", false);
                    animator.SetBool("IsJump", false);
                    break;
                case SantaState.walk:
                    animator.SetBool("IsIdle", false);
                    animator.SetBool("IsWalk", true);
                    animator.SetBool("IsJump", false);
                    break;
                case SantaState.jump:
                    animator.SetBool("IsIdle", false);
                    animator.SetBool("IsWalk", false);
                    animator.SetBool("IsJump", true);
                    break;
            }
            yield return null;
        }
    }
}
