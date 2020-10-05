using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float ReleaseDistance = 0.2f;
    public float MaxSlingshotTention = 2f;

    public Rigidbody2D SlingshotRigidBody;

    private bool _isPressed = false;

    private Rigidbody2D _rigidBody;
    private SpringJoint2D _springJoint;

    private bool _canCalculateDistanceToStart = false;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _springJoint = GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        if (_isPressed)
        {
            Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(_mousePosition, SlingshotRigidBody.position) > MaxSlingshotTention)
            {
                _rigidBody.position = SlingshotRigidBody.position + 
                (_mousePosition - SlingshotRigidBody.position).normalized * MaxSlingshotTention;
            }
            else
                _rigidBody.position = _mousePosition;
        }

        //if (!_isPressed && _canCalculateDistanceToStart && Vector3.Distance(_rigidBody.position, SlingshotRigidBody.position) < ReleaseDistance)
        //    _springJoint.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            AudioManager.instance.Play("WallTouch");
    }

    private void OnMouseDown()
    {
        SetVariables(true, true, true);
    }

    private void OnMouseUp()
    {
        SetVariables(false, false);

        StartCoroutine(DestroySpringJoint());
    }

    private IEnumerator DestroySpringJoint()
    {
        yield return new WaitForSeconds(ReleaseDistance);

        _springJoint.enabled = false;
    }

    private void SetVariables(bool isPressed, bool isKinematic)
    {
        _isPressed = isPressed;
        _rigidBody.isKinematic = isKinematic;
    }

    private void SetVariables(bool isPressed, bool isKinematic, bool canCalculateDistanceToStart)
    {
        _isPressed = isPressed;
        _rigidBody.isKinematic = isKinematic;
        _canCalculateDistanceToStart = canCalculateDistanceToStart;
    }

    public void SetBooleans(bool isPressed, bool canCalculateDistanceToStart)
    {
        _isPressed = isPressed;
        _canCalculateDistanceToStart = canCalculateDistanceToStart;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SlingshotRigidBody.position, MaxSlingshotTention);
        Gizmos.color = Color.red;
    }
}
