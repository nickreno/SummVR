using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class BeatButton : MonoBehaviour
{
    Vector3 old;
    bool isPressed = false;
    AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hands" && isPressed == false)
        {
            old = transform.localPosition;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.0003f, transform.localPosition.z);
            isPressed = true;
            audioSource.PlayOneShot(clip);
            StartCoroutine(Unpress());

        }
    }
    IEnumerator Unpress()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = old;
        isPressed = false;
    }
}
