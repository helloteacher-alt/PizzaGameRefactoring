using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleController : MonoBehaviour
{
    public List<ItemType> ItemList = new List<ItemType>();
    List<ItemType> shuffledList = new List<ItemType>();
    List<ItemType> clonnedItems = new List<ItemType>();
    public Button boxPrefab;
    public Transform parent;
    public List<Button> instantiatedItems = new List<Button>();
    public bool IsDisable = false;


    

    void Start()
    {
        Reset();
    }

    

    void InstantiateItem(List<ItemType> items)
    {
        foreach (Button item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }
        instantiatedItems.Clear();
        instantiatedItems = new List<Button>();
        float positionY = 0;
        float positionX = 1.5f;
        clonnedItems = new List<ItemType>(shuffledList);
        for (int i = 0; i < items.Count; i++)
        {
            Button item = Instantiate(boxPrefab, new Vector3(positionX, positionY, 0f), Quaternion.identity, parent);

            item.name = i.ToString();
            item.onClick.AddListener(() => OnClicked(clonnedItems, item.name));
            instantiatedItems.Add(item);

            positionY = (i / 3) * 30;
            positionX = (i % 3) * 30;

            RectTransform transform = item.gameObject.transform as RectTransform;
            Vector2 position = transform.anchoredPosition;
            transform.anchoredPosition = new Vector2(positionX, positionY);
        }
    }

    void OnClicked(List<ItemType> items, string index)
    {
        if (IsDisable)
        {
            return;
        }
        Image target = GameObject.Find(index).GetComponentInChildren<Image>();
        ItemType item = items[int.Parse(index)];
        Debug.Log("Onclicked: " + item.GetName());

        target.sprite = item.image;
        target.gameObject.SetActive(true);

        if (item.type == ItemType.ItemsType.Coin100)
        {
            StartCoroutine(CallReset(4));
        }
    }

    void Reset()
    {
        shuffledList = Shuffle(new List<ItemType>(ItemList));
        InstantiateItem(shuffledList);
    }

    IEnumerator CallReset(float seconds)
    {
        IsDisable = true;
        yield return new WaitForSeconds(seconds);
        IsDisable = false;
        Reset();
    }

    private List<ItemType> Shuffle(List<ItemType> inputList)
    {
        List<ItemType> clonedList = new List<ItemType>(inputList);
        List<ItemType> resultList = new List<ItemType>();
        while (clonedList.Count > 0)
        {
            int randomIndex = Random.Range(0, clonedList.Count);
            ItemType pickedItem = clonedList[randomIndex];
            resultList.Add(pickedItem);
            clonedList.RemoveAt(randomIndex);
        }
        return resultList;
    }
}

