using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCalculator : MonoBehaviour
{
    #region Variables
    [SerializeField] private int currentCurrency;
    [SerializeField] private int currentMetricSystem;
    #endregion

    #region References
    private ProductsManager manager = null;
    private MenuManager menu = null;

    [Header("INPUT")]
    [SerializeField] private InputField productNameInputField;
    [SerializeField] private InputField priceInputInputField;
    [SerializeField] private InputField amountInputInputField;

    [Header("OUTPUT")]
    [SerializeField] private Text outputText;
    #endregion

    private void Start()
    {
        GetReferences();
    }

    public void GetOutput()
    {
        string nameString = productNameInputField.text;
        float price = float.Parse(priceInputInputField.text);
        float amount = float.Parse(amountInputInputField.text);

        float multiplier = currentMetricSystem == 0 ? 1000 : 1;

        float output = multiplier * (price / amount);

        manager.AddProduct(nameString, price, amount);
        menu.DisableNewProductMenu();
    }

    public void ResetNewProductData()
    {
        productNameInputField.text = "";
        priceInputInputField.text = "";
        amountInputInputField.text = "";
    }

    private void GetReferences()
    {
        manager = GetComponentInParent<ProductsManager>();
        menu = GetComponentInParent<MenuManager>();
    }
}
