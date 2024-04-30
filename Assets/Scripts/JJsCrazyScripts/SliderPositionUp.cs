using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliderPositionUp : MonoBehaviour
{
    public GameObject ulimit;
    public GameObject llimit;
    public GameObject Record;
    float speed;
    float prevY;
    float tprev;
    protected float sv;
    // Start is called before the first frame update
    void Start()
    {
        sv = transform.localPosition.y;
        SliderAction();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hands")
        {
            prevY = other.transform.position.y;
            tprev = transform.localPosition.y;
            if (transform.position.y < ulimit.transform.position.y && transform.position.y > llimit.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            }
            else if (transform.position.y >= ulimit.transform.position.y && prevY < ulimit.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            }
            else if (transform.position.y <= llimit.transform.position.y && prevY > llimit.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            }
            sv = transform.localPosition.y;
            Debug.Log(sv);
            if (Record.GetComponent<DJRecord>().spManip == false)
            {
                SliderAction();
            }
        }
    }
    public virtual void SliderAction()
    {
        // override this with action the slider performs
    }
}
