using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{

    [SerializeField] private int amount;
    [SerializeField] private int desiseredTargetAge;
    private int counter = 0;

    private List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        CreateListWithItems(amount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DateTime startTime = DateTime.Now;

            Debug.Log("klik");
            int answer = SearchForTarget(desiseredTargetAge);
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;

            Debug.Log("Binary time : " + timeSpan.Milliseconds + " milliseconds");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            DateTime startTime = DateTime.Now;

            NormalSearch();

            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;
            Debug.Log("Normal time : " + timeSpan.Milliseconds + " milliseconds");

        }
    }

    private void NormalSearch()
    {
        foreach (Item item in items)
        {
            if (item.age == desiseredTargetAge)
            {
                return;
            }
        }
    }



    private int SearchForTarget(int desiseredTargetAge)
    {
        int lastTarget = items.Count / 2;
        int targetAge;
        int newLenght;
        int SearchDirection = 1;


        int leftPoint = 0;
        int rightPoint = items.Count - 1;
        int midPoint;
        while (leftPoint <= rightPoint)
        {
            midPoint = (rightPoint + leftPoint) / 2;

            if (items[midPoint].age > desiseredTargetAge)
            {
                rightPoint = midPoint - 1;
            }
            else if (items[midPoint].age < desiseredTargetAge)
            {
                leftPoint = midPoint + 1;
            }
            else
            {
                return 1;
            }
        }

        return -1;
    }

    private void CreateListWithItems(int numbers)
    {
        for (int i = 0; i < numbers; i++)
        {
            Item item = new Item(i);
            items.Add(item);
        }
    }
}
