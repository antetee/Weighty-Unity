using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsManager : MonoBehaviour
{
    [SerializeField] private List<Product> products;
    [SerializeField] private List<GameObject> productGameObjects;

    [SerializeField] private GameObject productBase = null;

    [SerializeField] private Transform productsParent = null;

    private bool firstTime = true;

    private void Start()
    {
        InitProductsList();
        LoadData();
    }

    public void AddProduct(string name, float _price, float _amount)
    {
        string output = GetProductOutput(_price, _amount);
        products.Add(new Product(name, output, _price, _amount, products.Count + 1));
        AddProductUI(products[products.Count - 1]);
    }

    public string GetProductOutput(float price, float amount)
    {
        float outputPrice = 1000 * (price / amount);
        string outputFinal = outputPrice.ToString("0.00") + (" kn/ kg");
        return outputFinal;
    }

    public void RemoveProduct(int index)
    {
        products.RemoveAt(index);
        //Remove the product UI Element
        RemoveProductUI(index);
    }

    private void AddProductUI(Product newProduct)
    {
        GameObject newProductGO = Instantiate(productBase, productsParent);
        newProductGO.GetComponent<ProductUIConstructor>().UpdateProductUI(newProduct);

        productGameObjects.Add(newProductGO);
    }

    private void RemoveProductUI(int index)
    {
        Destroy(productGameObjects[index]);
        productGameObjects.RemoveAt(index);
    }

    public void EditProduct(int productIndex, string newName, float newPrice, float newAmount)
    {
        products[productIndex].productName = newName;
        products[productIndex].price = newPrice;
        products[productIndex].amount = newAmount;

        //Calculate new output
        products[productIndex].output = GetProductOutput(newPrice, newAmount);
        productGameObjects[productIndex].GetComponent<ProductUIConstructor>().UpdateProductUI(products[productIndex]);
    }

    public Product GetProduct(int index)
    {
        return products[index];
    }

    public void SaveData()
    {
        if(products.Count != null)
        {
            int productAmount = 0;
            int numberSuffix = 1;
            for (int i = 0; i < products.Count; i++)
            {
                string newKey = "product";
                PlayerPrefs.SetString(newKey + numberSuffix, products[i].productName);
                numberSuffix++;

                PlayerPrefs.SetString(newKey + numberSuffix, products[i].output);
                numberSuffix++;

                PlayerPrefs.SetFloat(newKey + numberSuffix, products[i].price);
                numberSuffix++;

                PlayerPrefs.SetFloat(newKey + numberSuffix, products[i].amount);
                numberSuffix++;

                productAmount++;
            }
            PlayerPrefs.SetInt("productCount", productAmount);
            PlayerPrefs.Save();
        }
    }

    public void LoadData()
    {
        Debug.Log("Loading....");
        int prefKeySuffix = 0;
        string prefKey = "product" + prefKeySuffix;

        for(int i = 1; i < PlayerPrefs.GetInt("productCount") + 1; i++)
        {
            Debug.Log("ing");

            prefKeySuffix++;
            prefKey = "product" + prefKeySuffix;
            Debug.Log(prefKey);

            string productName = PlayerPrefs.GetString(prefKey);
            prefKeySuffix++;
            prefKey = "product" + prefKeySuffix;
            Debug.Log(prefKey);

            string productOutput = PlayerPrefs.GetString(prefKey);
            prefKeySuffix++;
            prefKey = "product" + prefKeySuffix;
            Debug.Log(prefKey);

            float productPrice = PlayerPrefs.GetFloat(prefKey);
            prefKeySuffix++;
            prefKey = "product" + prefKeySuffix;
            Debug.Log(prefKey);

            float productAmount = PlayerPrefs.GetFloat(prefKey);

            if (productName != null)
            {
                //Add product
                AddProduct(productName, productPrice, productAmount);
                Debug.Log("Product1" + " " + productName + " " + productOutput + " " + productPrice + " " + productAmount);
            }
        }
    }

    private void InitProductsList()
    {
        if (firstTime)
        {
            products = new List<Product>();
            productGameObjects = new List<GameObject>();
            firstTime = false;
        }
    }
}
