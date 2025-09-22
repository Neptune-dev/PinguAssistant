using System.Collections.Generic;
using UnityEngine;

public class Pingu : MonoBehaviour
{
    [SerializeField] Camera cam;
    public bool skinEnabled;
    public int startSkinID;
    [SerializeField] List<AnimatorOverrideController> skins = new List<AnimatorOverrideController>();
    [SerializeField] float smoothTime = .3f;
    [SerializeField] float treshold = 0f;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector3 oldPos;
    float speed;

    Vector2 position = Vector2.zero;

    void Start ()
    {
        animator = GetComponent<Animator>();
        changeSkin(startSkinID);
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldPos = transform.position;
    }

    void FixedUpdate ()
    {
        followMouse();
        anim(); 
    }

    void followMouse ()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePos, ref position, smoothTime);
    }

    void anim ()
    {
        Vector2 velocity = transform.position - oldPos;
        speed = velocity.magnitude * 100;
        oldPos = transform.position;

        if (speed >= treshold) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (velocity.x < 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }

    public void changeSkin (int ID)
    {
        if (skinEnabled) 
        {
            animator.runtimeAnimatorController = skins[ID] as RuntimeAnimatorController;
        } else
        {
            animator.runtimeAnimatorController = skins[0] as RuntimeAnimatorController;
        }
    }
}
