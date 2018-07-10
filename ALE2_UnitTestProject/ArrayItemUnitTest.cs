using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class ArrayItemUnitTest
    {
        [TestMethod]
        public void stateNameShouldBeTheSame()
        {
            string[] array = {"a","b"};
            _2DArrayList item = new _2DArrayList("A",array);
            Assert.AreEqual(item.state, "A");
        }
        [TestMethod]
        public void stateNameShouldNotBeTheSame()
        {
            string[] array = { "a", "b" };
            _2DArrayList item = new _2DArrayList("A", array);
            Assert.AreNotEqual(item.state, "f");
        }
        [TestMethod]
        public void transitionsShouldBeTheSame()
        {
            string[] array = { "a", "b" };
            _2DArrayList item = new _2DArrayList("A", array);
            Assert.AreEqual(item.transtions, array);
        }
        [TestMethod]
        public void transitionAtIndexShouldBeTheSame()
        {
            string[] array = { "a", "b" };
            _2DArrayList item = new _2DArrayList("A", array);
            Assert.AreEqual(item.transtions[0], "a");
        }
    }
}
