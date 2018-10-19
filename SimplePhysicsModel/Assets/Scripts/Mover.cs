using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    private float _force = 5;

    private Vehicle _vehicle;

    private void Awake() {
        _vehicle = GetComponent<Vehicle>();
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _vehicle.ApplyForce(Vector3.back * _force);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            _vehicle.ApplyForce(Vector3.forward * _force);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            _vehicle.ApplyForce(Vector3.right * _force);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            _vehicle.ApplyForce(Vector3.left * _force);
        }
    }

}
