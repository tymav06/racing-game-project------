using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerval;
    float timerValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timerval.text = "time:"; 
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.unscaledDeltaTime;
        timerval.text = timerValue.ToString();
    }
}
