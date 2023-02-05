using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlowChartManager : MonoBehaviour
{
    public Flowchart fl;
    public GameObject[] goToActivegoToActive;

    public static FlowChartManager Instance;

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

 

    public void SetFlowChart(Flowchart flowchart)
    {
        fl = flowchart;
    }
    
    public  void CallBlock (String nextNode)
    {
        fl.ExecuteBlock(nextNode);
    }
}
