using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanels : MonoBehaviour
{
    [SerializeField] private GameObject panelToActivate;
    [SerializeField] private GameObject panelToDeactivate;

    Button myButton;
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(GoToPanel);
    }

    void GoToPanel()
    {
        panelToActivate.SetActive(true);
        panelToDeactivate.SetActive(false);
    }
}
