using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECashStash : MonoBehaviour
{

    int balance;
    // Start is called before the first frame update
    public void Collect(int amount)
    {
        balance += amount;
        Debug.Log(name + " have " + amount + " ecash");
    }
}
