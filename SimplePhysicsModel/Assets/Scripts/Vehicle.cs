using UnityEngine;

public class Vehicle : MonoBehaviour {

    private Vector3 _velocity;
    private Vector3 _acceleration;

    private const float Epsilon = .01f;

    [SerializeField]
    private float _mass = 1;

    [SerializeField, Range(1, 10)]
    private float _velocityLimit = 1;

    [SerializeField, Range(0, 1)]
    private float _frictionScaler = .5f;

    private void Update() {
        ApplyFriction();
        ApllyForces();
    }


    // second Newton law
    // tell to us that body acceleration it's force which we apply to body divided by mass of this body
    public void ApplyForce(Vector3 force) {
        _acceleration += force / _mass;
    }

    private void ApplyFriction() {
        var friction = -_velocity.normalized * _frictionScaler;
        ApplyForce(friction);
    }

    private void ApllyForces() {
        // set current 
        _velocity += _acceleration * Time.deltaTime;

        // limit velocity
        _velocity = Vector3.ClampMagnitude(_velocity, _velocityLimit);

        //on small velocities body might start to blink
        // so we considering small velocities as zero
        if (_velocity.magnitude < Epsilon) {
            _velocity = Vector3.zero;
            return;
        }

        transform.position += _velocity * Time.deltaTime;
        _acceleration = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(_velocity);
    }
}
