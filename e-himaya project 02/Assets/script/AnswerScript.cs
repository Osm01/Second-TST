using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class AnswerScript : MonoBehaviour
{
   public bool isCorrect = false;
    public Quizmanager quizmanager;
    public Color startColor;
    
    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        StartCoroutine(ColorTime());
    }
    IEnumerator ColorTime()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(2);
            Debug.Log("correct");
            quizmanager.Correct();


        }
        else
        {
            GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(2);
            Debug.Log("not correct");
            quizmanager.Wrong();

        }
        for (int i = 0; i < quizmanager.options.Length; i++)
        {
            quizmanager.options[i].GetComponent<Image>().color = Color.yellow;
        }

    }
}
