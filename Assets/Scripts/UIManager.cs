using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TriggerZone Level2Trigger;
    public GameObject Level1Graphics;
    public GameObject Level2Graphics;
    public GameManager Manager;
    public TMPro.TMP_Text InstructionText;
    public bool switched = false;

    Dictionary<string, bool> objectiveText = new Dictionary<string, bool>();

    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level2Trigger.Triggered && !switched) 
        { 
            Level1Graphics.SetActive(false); 
            Level2Graphics.SetActive(true);
            UpdateText();
            switched = true;
        }
        UpdateText();
    }

    void UpdateText()
    {
        string text = "";
        InstructionText.text = text;
        // this is bad... but runs fine?
        objectiveText.Clear();

        if (!switched)
        {
            //Debug.Log("stage 1");
            for (int i = 0; i < Manager.Objectives.Count; i++)
            {
                objectiveText[Manager.Objectives[i].Message] = Manager.Objectives[i].isComplete;
            }
        }
        else if (switched)
        {
            //Debug.Log("stage 2");
            for (int i = 0; i < Manager.Objectives2.Count; i++)
            {
                objectiveText[Manager.Objectives2[i].Message] = Manager.Objectives2[i].isComplete;
            }
        }

        // build text string
        foreach (string message in objectiveText.Keys)
        {
            text += message;
            if (objectiveText[message]) text += " (complete)";
            text += "\n\n";
        }

        InstructionText.text = text;
    }
}
