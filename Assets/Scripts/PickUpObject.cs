using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public List<GameObject> gameObjs;
    public GameObject selected;
    public List<SpriteRenderer> possibleToppingsList = new List<SpriteRenderer>();
    public Dictionary<string, int> holdInHand = new Dictionary<string, int>();

    public GameObject coinCount;
    public GameObject finish;


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Pickable"))
        {
            gameObjs.Add(target.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag("Pickable"))
        {
            gameObjs.Remove(target.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D placableObject)
    {
        if (placableObject.CompareTag("Placeble"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (placableObject.GetComponent<Placable>().IsServing)
                {
                    Debug.Log("Served");
                    coinCount.gameObject.GetComponent<CoinCount>().GetCoinCount();
                    finish.GetComponent<RecipeShow>().ShowTextFinishText();
                }
                if (selected != null)
                {
                    PickableObject ingrediant = selected.GetComponent<PickableObject>();
                    if (ingrediant != null)
                    {
                        placableObject.GetComponent<Placable>().Place(ingrediant.ingrediantName);
                        selected = null;
                        foreach (SpriteRenderer topping in possibleToppingsList)
                        {
                            topping.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    if (holdInHand.Keys.Count > 0)
                    {
                        placableObject.GetComponent<Placable>().ingrediants = new Dictionary<string, int>(holdInHand);
                        placableObject.GetComponent<Placable>().Oven();
                        holdInHand.Clear();
                        placableObject.GetComponent<Placable>().Render();
                        Render();
                    }
                    else
                    {
                        holdInHand = new Dictionary<string, int>(placableObject.GetComponent<Placable>().ingrediants);
                        placableObject.GetComponent<Placable>().ingrediants.Clear();
                        placableObject.GetComponent<Placable>().Render();
                        Render();
                    }
                }
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObjs.Count > 0)
            {
                gameObjs.Sort((a, b) => (int)(Vector3.Distance(a.transform.position, transform.position) - Vector3.Distance(b.transform.position, transform.position)));
                selected = gameObjs[0];
                holdInHand.Clear();
                Render();
                foreach (SpriteRenderer topping in possibleToppingsList)
                {
                    if (selected.GetComponent<PickableObject>().ingrediantName == topping.gameObject.name)
                    {
                        topping.gameObject.SetActive(true);
                    }
                    else topping.gameObject.SetActive(false);
                }
            }
            if (selected == null)
            {

            }
        }
    }

    public void Render()
    {
        foreach (SpriteRenderer topping in possibleToppingsList)
        {
            if (holdInHand.ContainsKey(topping.gameObject.name) && holdInHand[topping.gameObject.name] == 1)
            {
                topping.color = new Color(207f / 255f, 132f / 255f, 46f / 255f);
            }
            else topping.color = Color.white;
            if (holdInHand.ContainsKey(topping.gameObject.name))
            {
                topping.gameObject.SetActive(true);
            }
            else topping.gameObject.SetActive(false);

        }
    }
}

