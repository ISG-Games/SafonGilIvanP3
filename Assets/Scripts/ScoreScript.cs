using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int cScore;
    public static int winScoreInt;
    int scoreTotal;
    int score1;
    int score2;
    int score3;
    int score4;
    public Text TscoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        winScoreInt=0;
        cScore=0;
        scoreTotal=PlayerPrefs.GetInt("ScoreTotalP");
        score1=PlayerPrefs.GetInt("Score1P");
        score2=PlayerPrefs.GetInt("Score2P");
        score3=PlayerPrefs.GetInt("Score3P");
        score4=PlayerPrefs.GetInt("Score4P");
    }

    // Update is called once per frame
    void Update()
    {
        TscoreTotal.text="Score: "+scoreTotal+"/40";
        if (winScoreInt==1){
            Level1Record();
            winScoreInt=0;
        }
        if (winScoreInt==2){
            Level2Record();
            winScoreInt=0;
        }
        if (winScoreInt==3){
            Level3Record();
            winScoreInt=0;
        }
        if (winScoreInt==4){
            Level4Record();
            winScoreInt=0;
        }
    }

    public void Level1Record(){
        if (cScore>score1){
            PlayerPrefs.SetInt("Score1P",cScore);
            score1=PlayerPrefs.GetInt("Score1P");
            scoreTotal=score1+score2+score3+score4;
            PlayerPrefs.SetInt("ScoreTotalP",scoreTotal);
            cScore=0;
        }
    }
    public void Level2Record(){
        if (cScore>score2){
            PlayerPrefs.SetInt("Score2P",cScore);
            score2=PlayerPrefs.GetInt("Score2P");
            scoreTotal=score1+score2+score3+score4;
            PlayerPrefs.SetInt("ScoreTotalP",scoreTotal);
            cScore=0;
        }
    }
    public void Level3Record(){
        if (cScore>score3){
            PlayerPrefs.SetInt("Score3P",cScore);
            score3=PlayerPrefs.GetInt("Score3P");
            scoreTotal=score1+score2+score3+score4;
            PlayerPrefs.SetInt("ScoreTotalP",scoreTotal);
            cScore=0;
        }
    }
    public void Level4Record(){
        if (cScore>score4){
            PlayerPrefs.SetInt("Score4P",cScore);
            score4=PlayerPrefs.GetInt("Score4P");
            scoreTotal=score1+score2+score3+score4;
            PlayerPrefs.SetInt("ScoreTotalP",scoreTotal);
            cScore=0;
        }
    }
}
