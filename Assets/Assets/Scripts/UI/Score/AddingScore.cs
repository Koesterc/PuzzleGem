using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingScore : MonoBehaviour {
    int score;
    int add;
    Text myScore;
    IEnumerator _score;

    private void Start()
    {
        myScore = gameObject.GetComponent<Text>();
        _score = Score();
        AddScore(50000);
    } 

    public void AddScore(int score)
    {
        add += score;
        _score = Score();
        GameObject.Find("Canvas/UIText/PointsEarned").GetComponent<Text>().text = "+" + score.ToString("n0") + " Points";
        GameObject.Find("Canvas/UIText/PointsEarned").GetComponent<Animator>().Play("ComboMeter",0,0);
        StopCoroutine(_score);
        StartCoroutine(_score);
    }
    //tallying up the score
    public IEnumerator Score()
    {
        while (add > 0)
        {
            if (PauseMenus.gamePaused)
                break;
            if (add > 1600)
            {
                add -= 128;
                score += 128;
            }
            if (add > 800)
            {
                add -= 64;
                score += 64;
            }
            if (add > 400)
            {
                add -= 32;
                score += 32;
            }
            if (add > 200)
            {
                add -= 16;
                score += 16;
            }
            else if (add > 150)
            {
                add -= 8;
                score += 8;
            }
            else if (add > 100)
            {
                add -= 4;
                score += 4;
            }
            else if (add > 50)
            {
                add -= 2;
                score += 2;
            }
            else if (add <= 50)
            {
                add -= 1;
                score += 1;
            }
            myScore.text = "Score: " + score.ToString("n0").Replace(score.ToString("n0"), "<color=#C5FFC3FF>" + score.ToString("n0") + "</color>");
            yield return new WaitForSeconds(.016f);
        }
    }
}
