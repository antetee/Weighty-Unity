using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductUIConstructor : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text outputText;
    [SerializeField] private int index;

    [SerializeField] private Product product;

    private MenuManager manager;

    private void Start()
    {
        manager = MenuManager.instance;
    }

    public int GetIndex()
    {
        return index;
    }

    public void UpdateProductUI(Product product)
    {
        nameText.text = product.productName;
        outputText.text = product.output;
        index = product.index;
    }

    public void OnButtonClicked()
    {
        manager.EnableEditProductMenu(index -1);
    }
}
