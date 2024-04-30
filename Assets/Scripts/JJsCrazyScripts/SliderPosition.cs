using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliderPosition : MonoBehaviour
{
    public GameObject ulimit;
    public GameObject llimit;
    public GameObject Record;
    float speed;
    float prevX;
    float tprev;
    protected float sv;
    // Start is called before the first frame update
    void Start()
    {
        sv = transform.localPosition.x;
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
            prevX = other.transform.position.x;
            tprev = transform.localPosition.x;
            if (transform.position.x < ulimit.transform.position.x && transform.position.x > llimit.transform.position.x)
            {
                transform.position = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= ulimit.transform.position.x && prevX < ulimit.transform.position.x)
            {
                transform.position = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= llimit.transform.position.x && prevX > llimit.transform.position.x)
            {
                transform.position = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
            }
            sv = transform.localPosition.x;
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
