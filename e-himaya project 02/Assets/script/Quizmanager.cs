using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[SerializeField]
public class Quizmanager : MonoBehaviour
{
    public List<QeustionsAndAnswers> QnA;
    public GameObject[] options;
    public int CurrentQuestion;
    public Text QuestionTxt;
    public Text ScoreTxt;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    int TotalQuestions = 0;
    public int score;
    private void Start()
    {
        GenerateQuestion();
        TotalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        
    }
    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
      
    }
  public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + TotalQuestions;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Wrong()
    {
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();

    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
            {
           options[i].GetComponent<AnswerScript>().isCorrect = false;
           

            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];
            if(QnA[CurrentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
            }
            }
    }
  
    void GenerateQuestion()
    {
        if(QnA.Count > 0 )
        {
            CurrentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[CurrentQuestion].Question;
            SetAnswers();
            
        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }
        

        
    }
    
}

