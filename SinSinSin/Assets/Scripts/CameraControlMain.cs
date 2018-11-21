using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlMain : MonoBehaviour {

    public GameObject playerCharacterRB;

    private Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - playerCharacterRB.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = playerCharacterRB.transform.position + offset;
    }
}
