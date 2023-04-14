using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Cut : MonoBehaviour
{
    public AudioClip snip;
    public float Volume = 1;
    AudioSource audio;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    public XRController controller = null;
    private Transform tool;
    bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    public void Active()
    {
        audio.PlayOneShot(snip, Volume); //play song on active
    }
    // Update is called once per frame
    void Update()
    {
        if (held == true)
        {
            if(controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) //grab trigger float
            {
                float clampValue = Mathf.Clamp01(triggerValue); //turn
                animator.SetFloat("Cut", clampValue); //set cyt float in animator to triggers output float
                Debug.Log("Trigger pressed" + clampValue);

            }
            else 
            {
                animator.SetFloat("Cut", 0); //if not pressed 0
            }
        }
    }
}
