using UnityEngine;
using TMPro;
using System.Collections;

public class Messages : MonoBehaviour
{
    [SerializeField] private TMP_Text messageField;
    void Start()
    {
        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        StartCoroutine(ShowMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'."));
        yield return null;
    }
    public IEnumerator ShowMessage(string message)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
}
