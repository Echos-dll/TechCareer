using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardMovementSpeed = 1f;
    [SerializeField] private float _horizontalMovementSpeed = 1f;
    
    private Vector3 m_movementVector;
    private Vector2 m_mousePreviousPosition;
    
    private void Awake()
    {
        m_movementVector = new Vector3();
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
        newPosition.z += _forwardMovementSpeed * Time.deltaTime;
        //Move horizontal
        newPosition.x += m_movementVector.x * _horizontalMovementSpeed * Time.deltaTime;
        
        transform.position += newPosition;
    }

    
}