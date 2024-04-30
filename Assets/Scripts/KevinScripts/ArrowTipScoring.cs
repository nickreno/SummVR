using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ArrowTipScoring : MonoBehaviour
{

    public bool hasScored;

    ScoreManager scoreManager;

    BoxCollider m_Collider;

    public int arrowID;

    public int targetID;

    public int myScoreMultiplier;

    //public GameObject FloatingTextPrefab;



    // Start is called before the first frame update
    void Start()
    {

        m_Collider = GetComponent<BoxCollider>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       /*Target target = other.GetComponent<Target>();
        if(target != null)
        {
            targetID = target.targetID;
        }
       */

       
            if (hasScored == false && other.CompareTag("1Point"))
            {
                Target target = other.GetComponent<Target>();
                myScoreMultiplier = target.scoreMultiplier;
                if (target != null)
                {
                    targetID = target.targetID;
                    if (targetID == arrowID)
                    {
                        hasScored = true;
                        scoreManager.addScore(arrowID, 1 * myScoreMultiplier);
                        m_Collider.enabled = !m_Collider.enabled;
                        scoreManager.ShowFloatingText(1 * myScoreMultiplier);
                    }
                }
            }else if (hasScored == false && other.CompareTag("2Point"))
        {
            Target target = other.GetComponent<Target>();
            myScoreMultiplier = target.scoreMultiplier;
            if (target != null)
            {
                targetID = target.targetID;
                if (targetID == arrowID)
                {
                    hasScored = true;
                    scoreManager.addScore(arrowID, 2 * myScoreMultiplier);
                    m_Collider.enabled = !m_Collider.enabled;
                    scoreManager.ShowFloatingText(2 * myScoreMultiplier);
                }
            }
        } else if (hasScored == false && other.CompareTag("3Point"))
        {
            Target target = other.GetComponent<Target>();
            myScoreMultiplier = target.scoreMultiplier;
            if (target != null)
            {
                targetID = target.targetID;
                if (targetID == arrowID)
                {
                    hasScored = true;
                    scoreManager.addScore(arrowID, 3 * myScoreMultiplier);
                    m_Collider.enabled = !m_Collider.enabled;
                    scoreManager.ShowFloatingText(3 * myScoreMultiplier);
                }
            }
        } else if (hasScored == false && other.CompareTag("4Point"))
        {
            Target target = other.GetComponent<Target>();
            myScoreMultiplier = target.scoreMultiplier;
            if (target != null)
            {
                targetID = target.targetID;
                if (targetID == arrowID)
                {
                    hasScored = true;
                    scoreManager.addScore(arrowID, 4 * myScoreMultiplier);
                    m_Collider.enabled = !m_Collider.enabled;
                    scoreManager.ShowFloatingText(4 * myScoreMultiplier);
                }
            }
        } else if (hasScored == false && other.CompareTag("BullsEye"))
        {
            Target target = other.GetComponent<Target>();
            myScoreMultiplier = target.scoreMultiplier;
            if (target != null)
            {
                targetID = target.targetID;
                if (targetID == arrowID)
                {
                    hasScored = true;
                    scoreManager.addScore(arrowID, 5 * myScoreMultiplier);
                    m_Collider.enabled = !m_Collider.enabled;
                    scoreManager.ShowFloatingText(5 * myScoreMultiplier);
                }
            }
        }

    }
       

}
