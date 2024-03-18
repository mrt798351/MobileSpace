using System;
using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    private void Start()
    {
        TextMeshProUGUI registrationText = GetComponent<TextMeshProUGUI>();
        EndGameManager.endManager.RegisterScoreText(registrationText);
        registrationText.text = "Score: 0";
    }
}
