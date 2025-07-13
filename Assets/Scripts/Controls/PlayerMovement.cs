using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RSK.Controls
{
    public class PlayerMovement : MonoBehaviour
    {
        private SpriteAnimator animator;
        private Rigidbody2D rigidBody;
        private PlayerInput input;
        private BasicPlayerControl basicPlayerControl;

        [SerializeField] private float speed = 10f;
        [SerializeField] private float idleThreshold = 0.5f;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            input = GetComponent<PlayerInput>();
            animator = GetComponent<SpriteAnimator>();

            basicPlayerControl = new BasicPlayerControl();
            basicPlayerControl.BasicPlayerMove.Enable();
            basicPlayerControl.BasicPlayerMove.Move.performed += OnMove;
        }

        private void FixedUpdate()
        {
            Vector2 inputVector = basicPlayerControl.BasicPlayerMove.Move.ReadValue<Vector2>();
            rigidBody.AddForce(new Vector2(inputVector.x, 0) * speed, ForceMode2D.Force);

            if(rigidBody.velocity.magnitude >= 0 && rigidBody.velocity.magnitude < idleThreshold) 
            {
                animator.SetState(false);
            }
            else 
            {
                animator.SetState(true);
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 inputVector = context.ReadValue<Vector2>();
            rigidBody.AddForce(new Vector2(inputVector.x, 0) * speed, ForceMode2D.Force);

            animator.ChangeDirection(inputVector.x);
        }
    }
}
