using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCard : MonoBehaviour
{
    public Button addCardButton;

    public GameObject DoneButton;
    public GameObject addCardButtonObj;
    public GameObject removeCardObj;
    public GameObject openCardObj;
    public GameObject AnswersinputFieldObj;
    public GameObject QuestioninputFieldObj;

    public List<Cards> cards = new List<Cards>();

    private Vector3 QuestionStartPoint = new Vector3(0, 0.7f, 10);
    private Vector3 QuestionFinishPoint = new Vector3(-1, 2, 10);
    private Vector3 AnswerStartPoint = new Vector3(0, 0.8f, 10);
    private Vector3 AnswerFinishPiont = new Vector3(1.3f, -2.2f, 10);


    public void AddCardInStack()
    {
        if (AnswersinputFieldObj.GetComponent<TMP_InputField>().text != "" & QuestioninputFieldObj.GetComponent<TMP_InputField>().text != "")
        {
            Debug.Log("Input Detected");
            cards.Add(new Cards(AnswersinputFieldObj.GetComponent<TMP_InputField>().text, QuestioninputFieldObj.GetComponent<TMP_InputField>().text));
            StartCoroutine(MoveObjNormalPosition());
            DoneButton.SetActive(false);
            addCardButton.interactable = true;
            AnswersinputFieldObj.GetComponent<TMP_InputField>().text = "";
            QuestioninputFieldObj.GetComponent<TMP_InputField>().text = "";
        }

        else if (QuestioninputFieldObj.GetComponent<TMP_InputField>().text == "")
        {
            openCardObj.GetComponent<Animation>().Play();
            Debug.Log("Must write somefing...");
        }

        else if (AnswersinputFieldObj.GetComponent<TMP_InputField>().text == "")
        {
            AnswersinputFieldObj.GetComponent<Animation>().Play();
            Debug.Log("Must write somefing...");
        }
    }

    public void AddCardButton()
    {
        SetVisibleObj();
        StartCoroutine(MoveObjAddPsoition());
        DoneButton.SetActive(true);
    }

    public void SetVisibleObj()
    {
        AnswersinputFieldObj.SetActive(true);
        addCardButton.interactable = false;
        openCardObj.GetComponent<Button>().interactable = false;
        removeCardObj.GetComponent<Button>().interactable = false;
        QuestioninputFieldObj.SetActive(true);
    }

    public IEnumerator MoveObjAddPsoition()
    {
        int speed = 150;
        float accuracy = 0.001f;

        while ((QuestionFinishPoint - openCardObj.transform.position).sqrMagnitude > accuracy || (AnswerFinishPiont - AnswersinputFieldObj.transform.position).sqrMagnitude > accuracy)
        {
            openCardObj.transform.position = Vector3.MoveTowards(openCardObj.transform.position, QuestionFinishPoint, Time.deltaTime * speed);
            AnswersinputFieldObj.transform.position = Vector3.MoveTowards(AnswersinputFieldObj.transform.position, AnswerFinishPiont, Time.deltaTime * speed);
            yield return null;
        }
        //Debug.Log("Corutine stoped");
    }

    public IEnumerator MoveObjNormalPosition()
    {
        int speed = 15;
        float accuracy = 0.001f;
        //Debug.Log("Coroutine started");

        while ((QuestionStartPoint - openCardObj.transform.position).sqrMagnitude > accuracy || (AnswerStartPoint - AnswersinputFieldObj.transform.position).sqrMagnitude > accuracy)
        {
            openCardObj.transform.position = Vector3.MoveTowards(openCardObj.transform.position, QuestionStartPoint, Time.deltaTime * speed);
            AnswersinputFieldObj.transform.position = Vector3.MoveTowards(AnswersinputFieldObj.transform.position, AnswerStartPoint, Time.deltaTime * speed);
            yield return null;
        }

        AnswersinputFieldObj.SetActive(false);
        QuestioninputFieldObj.SetActive(false);

        //Debug.Log("Coroutine Stoped");
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log($"Вопрос {openCardObj.transform.position}\n\tОтвет {AnwersinputFieldObj.transform.position}");
        if (cards.Count != 0)
        {
            Debug.Log(cards[cards.Count - 1].questions);
        }
        //Debug.Log(AnwersinputFieldObj.GetComponent<TMP_InputField>().text);
        
    }
}
