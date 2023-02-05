using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FlowChartManager : MonoBehaviour
{
    public Flowchart fl;
    public GameObject[] goToActivegoToActive;
    public Camera cam;
    public static FlowChartManager Instance;
    public string contra = "114avanti";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSizeCam(int size)
    {
        cam.orthographicSize = size;
    }

    public GameObject pc;
    public GameObject musica;
    public void OpenPuzleMusical()
    {
        pc.SetActive(false);
        musica.SetActive(true);
        SetSizeCam(10);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
    public void checkContra(TMP_InputField ip)
    {
        if (ip.text == contra)
        {
            OpenPuzleMusical();
        }
    }
    public void VerHabitacion()
    {
        SetSizeCam(50);
        foreach (var gb in goToActivegoToActive)
        {
            gb.SetActive(true);
        }
    }
    public void SetFlowChart(Flowchart flowchart)
    {
        fl = flowchart;
    }
    
    public  void CallBlock (String nextNode)
    {
        fl.ExecuteBlock(nextNode);
    }
}
