using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    public static MenuManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject productsMenu = null;
    [SerializeField] private GameObject newProductMenu = null;
    [SerializeField] private GameObject productsList = null;
    [SerializeField] private GameObject editProductMenu = null;
    [SerializeField] private GameObject returnButton = null;
    [SerializeField] private GameObject plusButton = null;
    [SerializeField] private GameObject saveButton = null;

    private ProductsManager manager = null;
    [SerializeField] private ProductCalculator calculator = null;
    [SerializeField] private EditProductManager editManager = null;

    [SerializeField] private GameObject title;

    private void Start()
    {
        LeanTween.scaleX(title, 1, 1f);

        GetReferences();
        EnableMainMenu();
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        productsMenu.SetActive(false);
        newProductMenu.SetActive(false);
        editProductMenu.SetActive(false);
        DisableButtons();
    }

    public void EnableCalculatorMenu()
    {
        productsMenu.SetActive(true);
        productsList.SetActive(true);
        mainMenu.SetActive(false);
        newProductMenu.SetActive(false);
        editProductMenu.SetActive(false);
        EnableButtons();
    }

    public void EnableNewProductMenu()
    {
        newProductMenu.SetActive(true);
        productsList.SetActive(false);
        editProductMenu.SetActive(false);
        DisableButtons();
        EnableOnScreenKeyboard();
    }

    public void DisableNewProductMenu()
    {
        calculator.ResetNewProductData();
        newProductMenu.SetActive(false);
        productsList.SetActive(true);
        editProductMenu.SetActive(false);
        EnableButtons();
    }

    public void EnableEditProductMenu(int index)
    {
        editManager.InitEditProductUI(manager.GetProduct(index), index);

        editProductMenu.SetActive(true);
        productsList.SetActive(false);
        newProductMenu.SetActive(false);
        DisableButtons();
        EnableOnScreenKeyboard();
    }

    public void DisableEditProductMenu()
    {
        editManager.ResetEditProductUI();

        editProductMenu.SetActive(false);
        productsList.SetActive(true);
        newProductMenu.SetActive(false);
        EnableButtons();
    }

    private void DisableButtons()
    {
        returnButton.SetActive(false);
        plusButton.SetActive(false);
        saveButton.SetActive(false);
    }

    private void EnableButtons()
    {
        returnButton.SetActive(true);
        plusButton.SetActive(true);
        saveButton.SetActive(true);
    }

    public void EnableOnScreenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void EnableOnScreenNumKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }

    private void GetReferences()
    {
        manager = GetComponent<ProductsManager>();
    }
}
