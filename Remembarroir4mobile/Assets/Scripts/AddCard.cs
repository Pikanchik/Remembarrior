using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCard : MonoBehaviour
{
    public Button addCardButton;

    public GameObject DoneButton;
    public GameObject addCardObj;
    public GameObject removeCardObj;
    public GameObject openCardObj;
    public GameObject AnwersinputFieldObj;
    public GameObject QuestioninputFieldObj;
    public List<Cards> cards = new List<Cards>();



    private Vector3 FinishPoint = new Vector3(-1, 2, 10);
    private Vector3 FinishPoint_input = new Vector3(1.3f, -2.2f, 10);

    public void AddCardInStack()
    {
        if (AnwersinputFieldObj.GetComponent<TMP_InputField>().text != null & QuestioninputFieldObj.GetComponent<TMP_InputField>().text != null)
        {
            Debug.Log("Input Detected");
            cards.Add(new Cards(AnwersinputFieldObj.GetComponent<TMP_InputField>().text, QuestioninputFieldObj.GetComponent<TMP_InputField>().text));
        }    
    }

    public void AddCardButton()
    {
        SetVisibleObj();
        StartCoroutine(MoveObj());
        DoneButton.SetActive(true);

    }

    public void SetVisibleObj()
    {
        AnwersinputFieldObj.SetActive(true);
        addCardButton.interactable = false;
        openCardObj.GetComponent<Button>().interactable = false;
        removeCardObj.GetComponent<Button>().interactable = false;
        QuestioninputFieldObj.SetActive(true);
    }

    public IEnumerator MoveObj()
    {
        while(openCardObj.transform.position != FinishPoint & AnwersinputFieldObj.transform.position != FinishPoint_input)
        {
            openCardObj.transform.position = Vector3.MoveTowards(openCardObj.transform.position, FinishPoint, Time.deltaTime * 150);
            AnwersinputFieldObj.transform.position = Vector3.MoveTowards(AnwersinputFieldObj.transform.position, FinishPoint_input, Time.deltaTime * 150);
            yield return null;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log($"Вопрос {openCardObj.transform.position}\n\tОтвет {AnwersinputFieldObj.transform.position}");
        if (cards[0] != null)
        {
            Debug.Log(cards[cards.Count - 1].questions);
        }
        
    }
}
