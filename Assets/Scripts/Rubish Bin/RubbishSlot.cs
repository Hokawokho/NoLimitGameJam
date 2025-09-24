using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RubbishSlot : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject rubbish;
    [SerializeField] private SlotFill fill;

    [Header("Settings")]

    [SerializeField] private float timer;

    private void Start()
    {
        GetNewTrash();
    }

    public void SlotClicked()
    {
        if (rubbish.activeInHierarchy)
        {
            StartCoroutine(SendRubbish());
        }
    }

    private IEnumerator SendRubbish()
    {
        rubbish.SetActive(false);
        fill.gameObject.SetActive(true);
        yield return new WaitForSeconds(timer);
        GetNewTrash();
    }

    private void GetNewTrash()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        rubbish.GetComponent<Image>().color = randomColor;

        rubbish.SetActive(true);
    }

}
