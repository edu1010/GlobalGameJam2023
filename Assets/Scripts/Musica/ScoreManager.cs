using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource musica;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    public TextMeshProUGUI textConsole;
    public string[] textos;
    static IEnumerator add;
    static IEnumerator invokelater;
    public static bool acabado = true;
    private static int maxScore = 0;
    void Start()
    {
        add= AddString();
        invokelater= InvokeAddLater();
        Instance = this;
        comboScore = 0;
        StartCoroutine(CallBlock());
    }

    IEnumerator CallBlock()
    {
        yield return new WaitUntil(() => musica.isPlaying == false);
        if (maxScore > 50)
        {
            FlowChartManager.Instance.CallBlock("victoria");
        }
        else
        {
            FlowChartManager.Instance.CallBlock("derrota");

        }
    }
    public static void Hit()
    {
        comboScore += 1;
        Instance.hitSFX.Play();
        if (acabado)
        {
            ScoreManager.Instance.StopCoroutine(add);
            add= ScoreManager.Instance.AddString();
            ScoreManager.Instance.StartCoroutine(add);
        }
        else
        {
            ScoreManager.Instance.StopCoroutine(invokelater);
            invokelater = ScoreManager.Instance.AddString();
            ScoreManager.Instance.StartCoroutine(invokelater);
        }
    }
    public static void Miss()
    {
        if (comboScore > maxScore)
            maxScore = comboScore;
        comboScore = 0;
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }

    IEnumerator InvokeAddLater()
    {
        yield return new WaitWhile(() => acabado== false);
        
        ScoreManager.Instance.StopCoroutine(add);
        add= ScoreManager.Instance.AddString();
        ScoreManager.Instance.StartCoroutine(add);
        
    }
    IEnumerator  AddString()
    {
        acabado = false;
        string toAdd = textos[Random.Range(0, textos.Length)];
        
        textConsole.text += toAdd;
        print("www "+textConsole.text.Length);
        if (textConsole.text.Length > 2100)
        {
            textConsole.text = toAdd;
        } 
        // foreach (char c in toAdd)
        // {
        //     textConsole.text += c;
        // }
        acabado = true;
        yield return new WaitForSeconds(0f);
    }
}
