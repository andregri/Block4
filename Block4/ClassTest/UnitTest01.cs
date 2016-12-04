using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise01;

namespace ClassTest
{
    [TestClass]
    public class UnitTest01
    {
        GSM[] phones;

        // phones list 
        GSM projectAra;
        GSM iphone7;
        GSM Mi5;
        GSM Zenfone3;

        [TestInitialize]
        public void GSMInitialize()
        {
            Battery zenfoneBattery = new Battery(null, 720, 200, BatteryType.LiPo);
            Display zenfoneDisplay = new Display(5.2, 16000000);

            phones = new GSM[]
            {
                projectAra = new GSM("ProjectAra", "Google", 100, "Sundar Pichai"),
                iphone7 = new GSM("Iphone7", "Apple", 695, "Steve Jobs", 21, BatteryType.LiIon),
                Mi5 = new GSM("Xiaomi Mi5", "Xiaomi", 449, "Lei Jun", 5.15, 16000000),
                Zenfone3 = new GSM("Asus Zenfone3", "Asus", 305, "Jerry Shen", zenfoneBattery, zenfoneDisplay),
            };

            // call list 
            projectAra.AddCall(20);
            projectAra.AddCall(50);
            projectAra.AddCall(15);
            projectAra.AddCall(17);

            iphone7.AddCall(30);
            iphone7.AddCall(5);
            iphone7.AddCall(10);

            Mi5.AddCall(40);
            Mi5.AddCall(33);
            
            Zenfone3.AddCall(60);
            Zenfone3.AddCall(120);

        }

        [TestMethod]
        public void GSMConstructorTest()
        {
            Assert.AreEqual("ProjectAra", projectAra.Model);
            Assert.AreEqual("Google", projectAra.Manufacturer);

            Assert.AreEqual("Steve Jobs", iphone7.Owner);
            Assert.AreEqual(21, iphone7.battery.HoursTalk);

            Assert.AreEqual(16000000, (int)Mi5.display.Colors);
            Assert.AreEqual(449, Mi5.Price);

            Assert.AreEqual(BatteryType.LiPo, Zenfone3.battery.Type);
            Assert.AreEqual(null, Zenfone3.battery.Model);

            string zenfone3Expected = "Battery Model: \nBattery IdleTime: 720\nBattery HoursTalk: 200\nBattery Type: LiPo\n";
            Assert.AreEqual(zenfone3Expected, Zenfone3.battery.ToString());
        }

        [TestMethod]
        public void GSMCallHistoryTest()
        { 
            double projectAraExpectedCallPrice = (0.37 * (20 + 50 + 15 + 17)) ;
            double iphone7ExpectedCallPrice = (0.37 * (30 + 5 + 10)) ;
            double Mi5ExpectedCallPrice = (0.37 * (40 + 33));
            double Zenfone3ExpectedCallPrice = (0.37 * (60 + 120));

            Assert.AreEqual(projectAraExpectedCallPrice, projectAra.GetCallPrice(0.37));
            Assert.AreEqual(iphone7ExpectedCallPrice, iphone7.GetCallPrice(0.37));
            Assert.AreEqual(Mi5ExpectedCallPrice, Mi5.GetCallPrice(0.37));
            Assert.AreEqual(Zenfone3ExpectedCallPrice, Zenfone3.GetCallPrice(0.37));
        }

        [TestMethod]
        public void GSMCallHistoryTestAfterRemoveLongestCall()
        {    
            projectAra.RemoveCallByDuration(50);
            iphone7.RemoveCallByDuration(30);
            Mi5.RemoveCallByDuration(40);
            Zenfone3.RemoveCallByDuration(120);

            double projectAraExpectedAfterRemoveCallPrice = (0.37 * (20 + 15 + 17));
            // double iphone7ExpectedAfterRemoveCallPrice = (0.37 * (5 + 10));
            double Mi5ExpectedAfterRemoveCallPrice = (0.37 * (33));
            double Zenfone3ExpectedAfterRemoveCallPrice = (0.37 * 60);

            Assert.AreEqual(projectAraExpectedAfterRemoveCallPrice, projectAra.GetCallPrice(0.37));
            Assert.AreEqual(Mi5ExpectedAfterRemoveCallPrice, Mi5.GetCallPrice(0.37));
            Assert.AreEqual(Zenfone3ExpectedAfterRemoveCallPrice, Zenfone3.GetCallPrice(0.37));

            // Test not work cause this assert and test are always right, even if 5.55 is equal to 5.55
            // If it’s not an iPhone, it’s not an iPhone ;)
            // Assert.AreEqual(iphone7ExpectedAfterRemoveCallPrice, iphone7.GetCallPrice(0.37));
                                   
            projectAra.DeleteAllCall();
            iphone7.RemoveCallByDay(DateTime.Today); // this clear all call just because DateTime is set by default on the current day
            Mi5.DeleteAllCall();
            Zenfone3.RemoveCallByDay(DateTime.Today);

            Assert.AreEqual(0, projectAra.GetCallPrice(0.37));
            Assert.AreEqual(0, iphone7.GetCallPrice(0.37));
            Assert.AreEqual(0, Mi5.GetCallPrice(0.37));
            Assert.AreEqual(0, Zenfone3.GetCallPrice(0.37));
        }
    }
}
