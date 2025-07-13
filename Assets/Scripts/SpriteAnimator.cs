using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private Sprite[] moveArray;
    private int currentFrame;
    private float timer;
    private float frameRate = 0.1f;
    private SpriteRenderer spriteRenderer;

    private enum State 
    {
        Idle,
        Move
    }
    State state;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        state = new State();
        state = State.Idle;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate) 
        {
            timer -= frameRate;

            switch (state) 
            {
                case State.Idle:
                    currentFrame = (currentFrame + 1) % frameArray.Length;
                    spriteRenderer.sprite = frameArray[currentFrame];
                    break;

                case State.Move:
                    currentFrame = (currentFrame + 1) % moveArray.Length;
                    spriteRenderer.sprite = moveArray[currentFrame];
                    break;
            }
            
        }
    }

    public void SetState(bool isMoving)
    {
        if (isMoving)
        {
            state = State.Move;
        }
        else
        {
            state = State.Idle;
        }
    }

    public void ChangeDirection(float x) 
    {
        if (x < 0) { spriteRenderer.flipX = true; }
        else if (x > 0) { spriteRenderer.flipX = false;}
    }


}
