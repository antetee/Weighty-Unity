using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public string productName;
    public string output;
    public float price;
    public float amount;
    public int index;

    public Product(string _productName, string _output, float _price, float _amount, int _index)
    {
        productName = _productName;
        output = _output;

        price = _price;
        amount = _amount;
        index = _index;
    }
}