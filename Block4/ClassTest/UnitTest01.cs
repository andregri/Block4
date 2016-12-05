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
                projectAra = new GSM("ProjectAra", "Google", 100m, "Sundar Pichai"),
                iphone7 = new GSM("Iphone7", "Apple", 695m, "Steve Jobs", 21, BatteryType.LiIon),
                Mi5 = new GSM("Xiaomi Mi5", "Xiaomi", 449m, "Lei Jun", 5.15, 16000000),
                Zenfone3 = new GSM("Asus Zenfone3", "Asus", 305m, "Jerry Shen", zenfoneBattery, zenfoneDisplay),
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
            decimal projectAraExpectedCallPrice = (0.37m * (20 + 50 + 15 + 17));
            decimal iphone7ExpectedCallPrice = (0.37m * (30 + 5 + 10));
            decimal Mi5ExpectedCallPrice = (0.37m * (40 + 33));
            decimal Zenfone3ExpectedCallPrice = (0.37m * (60 + 120));

            Assert.AreEqual(projectAraExpectedCallPrice, projectAra.GetCallPrice(0.37m));
            Assert.AreEqual(iphone7ExpectedCallPrice, iphone7.GetCallPrice(0.37m));
            Assert.AreEqual(Mi5ExpectedCallPrice, Mi5.GetCallPrice(0.37m));
            Assert.AreEqual(Zenfone3ExpectedCallPrice, Zenfone3.GetCallPrice(0.37m));
        }

        [TestMethod]
        public void GSMCallHistoryTestAfterRemoveLongestCall()
        {
            projectAra.RemoveCallByDuration(50);
            iphone7.RemoveCallByDuration(30);
            Mi5.RemoveCallByDuration(40);
            Zenfone3.RemoveCallByDuration(120);

            decimal projectAraExpectedAfterRemoveCallPrice = (0.37m * (20 + 15 + 17));
            decimal iphone7ExpectedAfterRemoveCallPrice = (0.37m * (5 + 10));
            decimal Mi5ExpectedAfterRemoveCallPrice = (0.37m * (33));
            decimal Zenfone3ExpectedAfterRemoveCallPrice = (0.37m * 60);

            Assert.AreEqual(projectAraExpectedAfterRemoveCallPrice, projectAra.GetCallPrice(0.37m));
            Assert.AreEqual(Mi5ExpectedAfterRemoveCallPrice, Mi5.GetCallPrice(0.37m));
            Assert.AreEqual(Zenfone3ExpectedAfterRemoveCallPrice, Zenfone3.GetCallPrice(0.37m));
            Assert.AreEqual(iphone7ExpectedAfterRemoveCallPrice, iphone7.GetCallPrice(0.37m));

            projectAra.DeleteAllCall();
            iphone7.RemoveCallByDay(DateTime.Today); // this clear all call just because DateTime is set by default on the current day
            Mi5.DeleteAllCall();
            Zenfone3.RemoveCallByDay(DateTime.Today);

            Assert.AreEqual(0, projectAra.GetCallPrice(0.37m));
            Assert.AreEqual(0, iphone7.GetCallPrice(0.37m));
            Assert.AreEqual(0, Mi5.GetCallPrice(0.37m));
            Assert.AreEqual(0, Zenfone3.GetCallPrice(0.37m));
        }
    }
}
