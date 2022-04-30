using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    int difficultyLevel;
    string[] possibleAnswers;
    string correctAnswer;
    string questionText;

    public Question(int difficulty, string question, string[] answers, string correct)
    {
        difficultyLevel = difficulty;
        possibleAnswers = answers;
        correctAnswer = correct;
        questionText = question;
    }

    public int getDifficultyLevel()
    {
        return difficultyLevel;
    }

    public string[] getAnswers()
    {
        return possibleAnswers;
    }

    public string getCorrectAnswer()
    {
        return correctAnswer;
    }

    public string getQuestionText()
    {
        return questionText;
    }
}
