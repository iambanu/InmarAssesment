﻿using OpenQA.Selenium;
using SpecFlowFramework.PageObjects;
using SpecFlowFramework.Utilities;
using SpecFlowProjectFramework.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectFramework.PageObjects
{
    internal class ProductDescriptionPage : BasePage
    {
        public ProductDescriptionPage(GlobalSettings settings) : base(settings)
        {
        }

        private bool _verifyAddToCart => driver.DoElementsExist(By.XPath("//span[text()='Add to Cart']"));
        private IWebElement _addToCartButton => driver.WaitForVisible(By.XPath("//span[text()='Add to Cart']"));
        private IWebElement _PrdouctNameTitle => driver.WaitForVisible(By.XPath("//div[@class='product-info-main']//span[@itemprop='name']"));
        private IWebElement _quantity => driver.WaitForVisible(By.Id("qty"));
        private IWebElement _priceInCart => driver.WaitForVisible(By.XPath("//div[@class='product-info-price']//span[@class='price']"));
        private IWebElement _successMessage => driver.WaitForVisible(By.XPath("//div[contains(@data-bind,'message.text')]"));
        private IWebElement _successShopingCartLink => driver.WaitForVisible(By.XPath("//div[contains(text(),'You added')]//a[text()='shopping cart']"));

        public bool VerifyAddToCartButton()
        {
            return _verifyAddToCart;
        }

        public void ClickOnAddToCartButton()
        {
            _addToCartButton.Click();
        }

        public string GetProductNameTitle()
        {
            return _PrdouctNameTitle.Text;
        }

        public string GetQunatityInCartPage()
        {
            return _quantity.GetAttribute("value");
        }

        public void Enterqunatity(string noOfItems)
        {
            _quantity.ClearAndSendKeys(noOfItems);
        }

        public string GetPriceInCartPage()
        {
            return _priceInCart.Text;
        }

        public string GetSuccessMessage()
        {
            return _successMessage.Text;
        }

        public void ClickOnShoppingCartLink()
        {
            _successShopingCartLink.Click();
        }

    }
}
