using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class IntelligenceMinigameInfo
{
    //[SerializeField]
    static Question[] questions = {
    new Question(1, "What is the first letter of the alphabet?", new string[]{"A", "B", "C", "D" }, "A"),
    new Question(1, "Which of these is a continent?", new string[]{"Venezuala", "Canada", "USA", "North America"}, "North America"),
    new Question(1, "What is 2 + 2?", new string[]{"3", "4", "0", "Not sure"}, "4"),
    new Question(1, "Which of these letters is not considered a vowel?", new string[]{"a", "e", "u", "w"}, "w"),

    new Question(2, "What was the video game character Mario orignally called?", new string[]{"Mario", "Jumpman", "Donkey Kong", "Pauline"}, "Jumpman"),
    new Question(2, "Who was president of the USA from 2008 - 2016?", new string[]{"David Krappenschitz", "Barack Obama", "Donald Trump", "The Rock"}, "Barack Obama"),
    new Question(2, "What party is Justin Trudeau part of?", new string[]{"Liberal", "Conservative", "Green Party", "NDP"}, "Liberal"),
    new Question(2, "Which of these is not a Canadian artist?", new string[]{"Drake", "The Weeknd", "Justin Bieber", "Ariana Grande"}, "Ariana Grande"),

    new Question(3, "Which one of these car companies is not based in Italy?", new string[]{"McLaren", "Lamborghini", "Ferrari", "Pagani"}, "McLaren"),
    new Question(3, "Which of these is not a Canadian record label?", new string[]{"Monstercat", "OVO Sound", "Roc-A-Fella Records", "XO"}, "Roc-A-Fella Records"),
    new Question(3, "What is the integral of 1?", new string[]{"1", "2", "infinity", "x"}, "x"),
    new Question(3, "Which of these is not a Canadian university?", new string[]{"University of Toronto", "University of Athabasca", "McMaster University", "MIT"}, "MIT"),
    };
    static int difficulty = 1;
    /*int totalQuestionsAnswered;
    int totalCorrectAnswers;*/
    public static Question[] getAllQuestions()
    {
        return questions;
    }

    public static List<Question> getQuestionsOfDifficulty()
    {
        List<Question> questionList = new List<Question>();
        Question[] allQuestions = getAllQuestions();
        for(int i = 0; i < allQuestions.Length; i++)
        {
            if(allQuestions[i].getDifficultyLevel() == getDifficulty())
            {
                questionList.Add(allQuestions[i]);
            }
        }
        return questionList;
    }

    public static int getDifficulty()
    {
        return difficulty;
    }

    public static void setDifficulty(int d)
    {
        difficulty = d;
    }
}
