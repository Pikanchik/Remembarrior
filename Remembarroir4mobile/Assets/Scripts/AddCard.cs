using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public Button addCardButton;

    public GameObject addCardObj;
    public GameObject removeCardObj;
    public GameObject openCardObj;
    public GameObject AnwersinputFieldObj;
    public GameObject QuestioninputFieldObj;



    private Vector3 FinishPoint = new Vector3(-1, 2, 10);
    private Vector3 FinishPoint_input = new Vector3(1.3f, -2.2f, 10);

    public void AddCardButton()
    {
        SetVisibleObj();
        StartCoroutine(MoveObj());

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

    public Cards AddCardInStack(string Question,string Answer)
    {
        Cards card = new Cards(Question, Answer);
        return card;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log($"Вопрос {openCardObj.transform.position}\n\tОтвет {AnwersinputFieldObj.transform.position}");
    }
}
