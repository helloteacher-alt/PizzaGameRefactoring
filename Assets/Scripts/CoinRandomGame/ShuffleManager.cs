using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleManager : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();
    List<Item> shuffledList = new List<Item>();
    List<Item> clonnedItems = new List<Item>();
    public Button boxPrefab;
    public Transform parent;
    public List<Button> instantiatedItems = new List<Button>();
    public bool IsDisable = false;

    //public GameObject Congrats;

    //public GameObject coinCount;

    public Text coinCountText;
    int totalCoin;

    void Start()
    {
        Reset();
        coinCountText.GetComponent<Text>();

        //Congrats.SetActive(false);
    }


    void InstantiateItem(List<Item> items)
    {
        foreach (Button item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }
        instantiatedItems.Clear();
        instantiatedItems = new List<Button>();
        float positionY = 0;
        float positionX = 1.5f;
        clonnedItems = new List<Item>(shuffledList);
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

    public void OnClicked(List<Item> items, string index)
    {
        if (IsDisable)
        {
            return;
        }
        Image target = GameObject.Find(index).GetComponentInChildren<Image>();
        Item item = items[int.Parse(index)];
        Debug.Log("Onclicked: " + item.GetName());

        if(item.GetName() == "Coin100")
        {
                totalCoin = totalCoin+ 100;
                coinCountText.text = totalCoin.ToString();
        }
        else if(item.GetName() == "Coin50")
        {
            totalCoin= totalCoin+50;
            coinCountText.text = totalCoin.ToString();
        }
        else if(item.GetName() == "Coin10")
        {
            totalCoin= totalCoin+10;
            coinCountText.text = totalCoin.ToString();
        }
        else if(item.GetName() == "Coin5")
        {
            totalCoin= totalCoin+5;
            coinCountText.text = totalCoin.ToString();
        }



        //coinCount.gameObject.GetComponent<CoinCountGame>().IncreaseCoin();

        target.sprite = item.image;
        target.gameObject.SetActive(true);

        if (item.type == Item.ItemType.Coin100)
        {
            //Congrats.SetActive(true);
            StartCoroutine(CallReset(4));
        }
    }

    void Reset()
    {
        shuffledList = Shuffle(new List<Item>(ItemList));
        InstantiateItem(shuffledList);
        
        //itemsCount.gameObject.GetComponent<ReduceNumOfItems>().ResetCount();
    }

    IEnumerator CallReset(float seconds)
    {
        IsDisable = true;
        yield return new WaitForSeconds(seconds);
        IsDisable = false;
        //Congrats.SetActive(false);
        Reset();
    }

    private List<Item> Shuffle(List<Item> inputList)
    {
        List<Item> clonedList = new List<Item>(inputList);
        List<Item> resultList = new List<Item>();
        while (clonedList.Count > 0)
        {
            int randomIndex = Random.Range(0, clonedList.Count);
            Item pickedItem = clonedList[randomIndex];
            resultList.Add(pickedItem);
            clonedList.RemoveAt(randomIndex);
        }
        return resultList;
    }
}
