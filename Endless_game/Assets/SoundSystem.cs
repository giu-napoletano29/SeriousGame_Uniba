using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    vThirdPersonController cc;
    private bool canSound;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<vThirdPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc._rigidbody.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            //GetComponent<AudioSource>().
            //GetComponent<AudioSource>().PlayDelayed(0.3f*cc.freeSpeed.runningSpeed);
            GetComponent<AudioSource>().PlayDelayed(0.17f);
        }

    }

}
