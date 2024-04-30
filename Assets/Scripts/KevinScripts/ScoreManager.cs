using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{

    public int archeryScore1;
    public int archeryScore2;

    public TMP_Text archeryScoreBoard;

    public TMP_Text archeryScoreBoard2;

    public GameObject FloatingTextPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        archeryScoreBoard.text = archeryScore1.ToString();
        archeryScoreBoard2.text = archeryScore2.ToString();

    }

    public void addScore(int scoreID, int point)
    {
        if(scoreID == 1)
        {
            archeryScore1 += point;
        }else if (scoreID == 2)
        {
            archeryScore2 += point;
        }
    }
    public void ShowFloatingText(float score)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = "+" + score.ToString();
    }

}
