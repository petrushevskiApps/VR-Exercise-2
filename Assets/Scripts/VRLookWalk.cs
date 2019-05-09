using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {

    [SerializeField]
    Transform vrCamera;

    [SerializeField]
    float speed = 30f;

    CharacterController character;
    float posX = 0;
    float posY = 0;

    // Use this for initialization
    private void Awake()
    {
        posY = vrCamera.transform.localPosition.y;
    }
    void Start ()
    {
        character = GetComponent<CharacterController>();
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        vrCamera.localPosition = new Vector3(vrCamera.localPosition.x, 0.771f, vrCamera.localPosition.z);
        Debug.Log(vrCamera.localPosition);
        if (vrCamera.eulerAngles.x > 15f && vrCamera.eulerAngles.x < 30f)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            character.SimpleMove(forward * speed * Time.deltaTime);
        }
    }
}
