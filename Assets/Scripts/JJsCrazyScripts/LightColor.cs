using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    private Light lite;
    // Start is called before the first frame update
    void Start()
    {
        lite = GetComponent<Light>();
        StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            lite.color = Color.magenta;
            yield return new WaitForSeconds(1);
            lite.color = Color.red;
            yield return new WaitForSeconds(1);
            lite.color = Color.green;
            yield return new WaitForSeconds(1);
            lite.color = Color.blue;
            yield return new WaitForSeconds(1);
            lite.color = Color.yellow;
            yield return new WaitForSeconds(1);
        }
    }
}
