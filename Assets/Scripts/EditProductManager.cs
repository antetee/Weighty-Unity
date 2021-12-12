using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditProductManager : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField priceInputField;
    [SerializeField] private InputField amountInputField;

    [SerializeField] int currentProductIndex;

    private ProductsManager manager;
    private MenuManager menu;

    private void Start()
    {
        GetReferences();
    }

    public void InitEditProductUI(Product product, int index)
    {
        nameInputField.text = product.productName;
        priceInputField.text = product.price.ToString();
        amountInputField.text = product.amount.ToString();
        currentProductIndex = index;
    }

    public void ResetEditProductUI()
    {
        nameInputField.text = "";
        priceInputField.text = "";
        amountInputField.text = "";
    }

    public void ApplyEditProduct()
    {
        manager.EditProduct(currentProductIndex, nameInputField.text, float.Parse(priceInputField.text), float.Parse(amountInputField.text));
        menu.DisableEditProductMenu();
    }

    public void RemoveProduct()
    {
        manager.RemoveProduct(currentProductIndex);
        menu.DisableEditProductMenu();
    }

    private void GetReferences()
    {
        manager = GetComponentInParent<ProductsManager>();
        menu = GetComponentInParent<MenuManager>();
    }
}
