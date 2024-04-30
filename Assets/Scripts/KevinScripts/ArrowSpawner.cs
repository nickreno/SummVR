using Photon.Voice;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowSpawner : MonoBehaviour
{

    public GameObject arrow;
    public GameObject notch;

    private XRGrabInteractable _bow;
    private bool _arrowNotched = false;
    private GameObject _currentArrow;

    public int BowID;
    //private GameObject _currentArrow = null;
    // Start is called before the first frame update
    void Start()
    {
        _bow = GetComponentInParent<XRGrabInteractable>();
        //Instantiate(arrow, notch.transform);
        GameObject newArrow = Instantiate(arrow, notch.transform);
        ArrowTipScoring scoringScript = newArrow.GetComponent<ArrowTipScoring>();
        //Instantiate(arrow, notch.transform);
        scoringScript.arrowID = BowID;
        PullInteraction.PullActionReleased += NotchEmpty;
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= NotchEmpty;
    }

    // Update is called once per frame
    void Update()
    {

        /*
         if(_bow.isSelected && _arrowNotched == false)
         {
             _arrowNotched = true;
             StartCoroutine("DelayedSpawn");
         }
         if(!_bow.isSelected && _currentArrow != null)
         {
             Destroy(_currentArrow);
             NotchEmpty(1f);
         }
         */

        if (_bow.isSelected && !_arrowNotched)
        {
            //yield return new WaitForSeconds(2);
            //Instantiate(arrow, notch.transform); 
            StartCoroutine(DelayedSpawn());
        }
        if (!_bow.isSelected)
        {
            Destroy(_currentArrow);
        }
    }

    private void NotchEmpty(float myFloat)
    {
        _arrowNotched = false;
        //_currentArrow = null;
    }


    IEnumerator DelayedSpawn()
    {
        _arrowNotched = true;
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Pulled an arrow");
        //_currentArrow = Instantiate(arrow, notch.transform);

        GameObject newArrow = Instantiate(arrow, notch.transform);
        ArrowTipScoring scoringScript = newArrow.GetComponent<ArrowTipScoring>();
        //Instantiate(arrow, notch.transform);
        scoringScript.arrowID = BowID;
    }
}
