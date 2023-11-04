using System;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class RunnerMovement : MonoBehaviour
    {
        [SerializeField] private float _forwardMovementSpeed = 1f;
        [SerializeField] private float _horizontalMovementSpeed = 1f;
        [SerializeField] private ScriptableEvent _gameStartEvent;
    
        private AnimationController m_animationController;
        
        private Vector3 m_movementVector;
        private Vector2 m_mousePreviousPosition;
        private float currentMovementSpeed;
        private bool gameStarted;
    
        private void Awake()
        {
            m_movementVector = new Vector3();
            m_animationController = GetComponent<AnimationController>();
        }

        private void Start()
        {
            currentMovementSpeed = 0;
            m_animationController.UpdateAnimationState(0);
        }

        private void Update()
        {
            CalculateMovement();
        }
    
        private void MovementInput()
        {
            if (!Input.anyKey)
            {
                m_movementVector = Vector3.zero;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                m_mousePreviousPosition = Vector2.zero;
                if (!gameStarted)
                {
                    _gameStartEvent.InvokeAction();
                    gameStarted = true;
                }
            }
        
            if (Input.GetMouseButton(0))
            {
                float mouseDelta = 0;
            
                mouseDelta = Input.mousePosition.x - m_mousePreviousPosition.x;
                m_mousePreviousPosition = Input.mousePosition;

                m_movementVector = Vector3.right * mouseDelta;
            
                m_movementVector.Normalize();
            }
        }

        private void CalculateMovement()
        {
            MovementInput();
        
            m_movementVector.Normalize();

            Vector3 newPosition = new Vector3();
            //Move forward
            newPosition.z += currentMovementSpeed * Time.deltaTime;
            //Move horizontal
            newPosition.x += m_movementVector.x * _horizontalMovementSpeed * Time.deltaTime;
            transform.position += newPosition;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -2, 2),
                transform.position.y,
                transform.position.z);
        }

        public void OnGameEnd()
        {
            currentMovementSpeed = 0;
            m_animationController.UpdateAnimationState(0);
        }

        private void OnGameStart()
        {
            currentMovementSpeed = _forwardMovementSpeed;
            m_animationController.UpdateAnimationState(1);
        }

        private void OnEnable()
        {
            _gameStartEvent.Subscribe(OnGameStart);
        }

        private void OnDisable()
        {
            _gameStartEvent.Unsubscribe(OnGameStart);
        }

        private void SaveGame()
        {
            //JSON Serialization
        }

        private void LoadGame()
        {
            //JSON Deserialization
            
        }
    }
}