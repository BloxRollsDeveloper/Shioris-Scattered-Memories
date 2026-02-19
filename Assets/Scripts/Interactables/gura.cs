using Ink.Parsed;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class Gura : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private TextMeshProUGUI questionText;

    [System.Serializable]
    public class Question
    {
        public string question;
        public int correctAnswer;
    }

    [Header("Questions (in order)")]
    [SerializeField] private List<Question> questions = new List<Question>();

    private int currentQuestionIndex = 0;

    private void Awake()
    {
        answerInput.onEndEdit.AddListener(CheckAnswer);
        feedbackText.gameObject.SetActive(false);

        ShowCurrentQuestion();
    }

    private void ShowCurrentQuestion()
    {

        feedbackText.gameObject.SetActive(false);

        if (currentQuestionIndex >= questions.Count)
        {

            questionText.text = "All questions completed!";
            answerInput.interactable = false;
            return;
        }

        Question q = questions[currentQuestionIndex];
        questionText.text = q.question;

        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    private void CheckAnswer(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return;

        if (!int.TryParse(input, out int playerAnswer))
        {
            ShowFeedback("Type a number first.", Color.yellow);
            return;
        }

        if (playerAnswer == questions[currentQuestionIndex].correctAnswer)
        {
            ShowFeedback("Gura is proud", Color.green);
            currentQuestionIndex++;
            Invoke(nameof(ShowCurrentQuestion), 1f);
        }
        else
        {
            ShowFeedback("Gura is dissapointed", Color.red);
        }
    }

    private void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
        feedbackText.gameObject.SetActive(true);
    }
}