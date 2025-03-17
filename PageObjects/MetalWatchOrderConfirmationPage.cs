using OpenQA.Selenium;
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
    public class MetalWatchOrderConfirmationPage : BasePage
    {
        public MetalWatchOrderConfirmationPage(GlobalSettings settings) : base(settings)
        {
        }
        private string _orderNo => driver.GetText(By.XPath("//p[text()='Your order number is: ']//a[@class='order-number']//strong"));
        public string GetOrderNo()
        {
            return _orderNo;
        }
    }
}
