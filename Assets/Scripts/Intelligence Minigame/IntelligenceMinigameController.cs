using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;

public class IntelligenceMinigameController : MonoBehaviour
{
    //IntelligenceMinigameInfo info;
    Question currentQuestion;
    [SerializeField] GameObject questionText;
    [SerializeField] GameObject answer1;
    [SerializeField] GameObject answer2;
    [SerializeField] GameObject answer3;
    [SerializeField] GameObject answer4;
    List<GameObject> answerButtons;
    public specimen2 specimen;
    float currentTimer = -1.0f;
    bool gameIsOver = false;

    private void Awake()
    {
        answer1.GetComponent<Button>().onClick.AddListener(OnClickOne);
        answer2.GetComponent<Button>().onClick.AddListener(OnClickTwo);
        answer3.GetComponent<Button>().onClick.AddListener(OnClickThree);
        answer4.GetComponent<Button>().onClick.AddListener(OnClickFour);
        answerButtons = new List<GameObject> { answer1, answer2, answer3, answer4 };
        //if(specimen.level == 1)
        //{
        specimen.LoadPlayer();
        IntelligenceMinigameInfo.setDifficulty(specimen.getLevel() % 4);
        //}
        //TestGameManager.setVar(5);
        
    }

    private void OnClickOne()
    {
        Debug.Log(answer1.GetComponentInChildren<TextMeshProUGUI>().text);
        Debug.Log(markAnswer(answer1));
        answerButtons.Remove(answer1);
        foreach(GameObject button in answerButtons) {
            button.GetComponent<Button>().enabled = false;
        }
        gameOver(markAnswer(answer1));
    }
    private void OnClickTwo()
    {
        Debug.Log(answer2.GetComponentInChildren<TextMeshProUGUI>().text);
        Debug.Log(markAnswer(answer2));
        answerButtons.Remove(answer2);
        foreach (GameObject button in answerButtons)
        {
            button.GetComponent<Button>().enabled = false;
        }
        gameOver(markAnswer(answer2));
    }
    private void OnClickThree()
    {
        Debug.Log(answer3.GetComponentInChildren<TextMeshProUGUI>().text);
        answerButtons.Remove(answer3);
        foreach (GameObject button in answerButtons)
        {
            button.GetComponent<Button>().enabled = false;
        }
        gameOver(markAnswer(answer3));
    }
    private void OnClickFour()
    {
        Debug.Log(answer4.GetComponentInChildren<TextMeshProUGUI>().text);
        answerButtons.Remove(answer4);
        foreach (GameObject button in answerButtons)
        {
            button.GetComponent<Button>().enabled = false;
        }
        gameOver(markAnswer(answer4));
    }
    private void Start()
    {
        //info = new IntelligenceMinigameInfo();
        currentQuestion = queryQuestion();
        queryAnswerSelection();
        int numAnswersToMark = 0;
        if (specimen.intelligence >= 10) numAnswersToMark = 1;
        if (specimen.intelligence >= 20) numAnswersToMark = 2;
        if (numAnswersToMark > 0)
        {
            foreach (GameObject answer in answerButtons)
            {
                if (!answer.GetComponentInChildren<TextMeshProUGUI>().text.Equals(currentQuestion.getCorrectAnswer()))
                {
                    markAnswer(answer);
                    numAnswersToMark--;
                    if (numAnswersToMark <= 0) break;
                }
            }
        }
    }
    bool gameOver(bool gotCorrectAnswer)
    {
        if(gotCorrectAnswer)
        {
            //TestGameManager.setVar(3);
            Results.setXPGained(50);
            Results.setIntelligenceGained(5);
            Results.setCurrencyGained(50);
            StartCoroutine(ShowResultsScreen(3.0f));
            //SceneManager.LoadScene("Results");
        }
        else
        {
            Results.setXPGained(-50);
            Results.setIntelligenceGained(-5);
            Results.setCurrencyGained(0);
            //TestGameManager.setVar(1);
            foreach (GameObject button in answerButtons)
            {
                markAnswer(button);
            }
            StartCoroutine(ShowResultsScreen(3.0f));
        }
        return true;
    }

    public IEnumerator ShowResultsScreen(float t)
    {
        yield return new WaitForSeconds(t);
        specimen.SavePlayer();
        SceneManager.LoadScene("Results");
    }

    void answerQuestion()
    {

    }

    //Return a random question that corresponds to the current difficulty level (default set at 1)
    Question queryQuestion()
    {
        List<Question> questions = IntelligenceMinigameInfo.getQuestionsOfDifficulty();
        int randomIndex = Mathf.RoundToInt(Random.Range(0.0f, questions.Count-1));
        return questions[randomIndex];
    }

    void queryAnswerSelection()
    {
        string[] possibleAnswers = currentQuestion.getAnswers();
        List<GameObject> answerObjects = new List<GameObject>
        {
            answer1,
            answer2,
            answer3,
            answer4
        };
        int i = 0;
        questionText.GetComponent<TextMeshProUGUI>().text = currentQuestion.getQuestionText();
        while (answerObjects.Count > 0)
        {
            int randomIndex = Mathf.RoundToInt(Random.Range(0.0f, answerObjects.Count - 1));
            answerObjects[randomIndex].GetComponentInChildren<TextMeshProUGUI>().text = possibleAnswers[i];
            answerObjects.RemoveAt(randomIndex);
            i++;
        }
    }

    bool markAnswer(GameObject answer)
    {
        if(answer.GetComponentInChildren<TextMeshProUGUI>().text.Equals(currentQuestion.getCorrectAnswer())) 
        {
            answer.GetComponent<Button>().GetComponent<Image>().color = Color.green;
        }
        else
        {
            answer.GetComponent<Button>().GetComponent<Image>().color = Color.red;
        }
        return answer.GetComponentInChildren<TextMeshProUGUI>().text.Equals(currentQuestion.getCorrectAnswer());
    }

    void adjustDifficulty()
    {

    }

    void adjustStats()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
