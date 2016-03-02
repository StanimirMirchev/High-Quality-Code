namespace DynamicList.test
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void GettingEmptyDynamicListOfIntsShouldReturnEmptyDynamicListOfIntsWhitZeroCount()
        {
            var dynamicListOfInts = new DynamicList<int>();

            Assert.AreEqual(0, dynamicListOfInts.Count, string.Format("Default count of DynamicList must be 0 not: {0}.", dynamicListOfInts.Count));
        }

        [TestMethod]
        public void AddingNewItemsSeveralTimesInDynamicListShouldReturnCountPlusThree()
        {
            var dynamicListOfStrings = new DynamicList<string>();
            int coutBeforAdding = dynamicListOfStrings.Count;

            dynamicListOfStrings.Add("0");
            dynamicListOfStrings.Add("1, 2 , 3");
            dynamicListOfStrings.Add("4");

            Assert.AreEqual(3, dynamicListOfStrings.Count, "The method \"Add\" does not work correctly");
        }

        [TestMethod]
        public void GetingElementAtCorrectPositionFromNoneEmptyDynamicListOfIntsShouldReturnCorrectElement()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            Assert.AreEqual(3, dynamicListOfInts[2],
                "Obtained value of getting a element whit operator \"[]\" is not as expected." +
                "\nNote that position couting should start from 0!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void GettingElementAtOutOfRangePositionFromNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            var outOfRangePosition = dynamicListOfInts[4];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void GettingElementAtNegativePositionFromNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            var negativePosition = dynamicListOfInts[-1];
        }

        [TestMethod]
        public void SettingElementAtCorrectPositionInNoneEmptyDynamicListOfIntsShouldReturnCorrectElements()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(0);
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            int startingCount = dynamicListOfInts.Count;

            dynamicListOfInts[0] = 1;
            bool isSettingAtPositionCorrect =
                dynamicListOfInts[0] == 1 &&
                dynamicListOfInts[1] == 1 &&
                dynamicListOfInts[2] == 2 &&
                dynamicListOfInts.Count == startingCount;

            Assert.AreEqual(true, isSettingAtPositionCorrect,
                string.Format("Operator \"[]\" does not work correctly when sets a element"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void SettingElementAtOutOfRangePositionInNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            dynamicListOfInts[4] = 4;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void SettingElementAtNegativePositionInNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            dynamicListOfInts[-1] = -1;
        }

        [TestMethod]
        public void RemovingElementAtCorrectPositionFromNoneEmptyDynamicListOfIntsShouldReturnCorrectObject()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(0);
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            int startingCount = dynamicListOfInts.Count;

            dynamicListOfInts.RemoveAt(1);
            bool isRemovedAtPositionCorrect =
                dynamicListOfInts[0] == 0 &&
                dynamicListOfInts[1] == 2 &&
                dynamicListOfInts.Count == startingCount - 1;

            Assert.AreEqual(true, isRemovedAtPositionCorrect,
                string.Format("The method \"RemoveAt\" does not work correctly!"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void RemovingElementAtOutOfRangePositionFromNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            dynamicListOfInts.RemoveAt(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void RemovingElementAtNegativePositionFromNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            dynamicListOfInts.RemoveAt(-1);
        }

        [TestMethod]
        public void RemovingElementFromNoneEmptyDynamicListOfIntsShouldReturnCorrectObject()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);
            int startingCount = dynamicListOfInts.Count;

            dynamicListOfInts.Remove(2);
            bool isRemovedCorrectly =
              dynamicListOfInts[0] == 1 &&
              dynamicListOfInts[1] == 3 &&
              dynamicListOfInts.Count == startingCount - 1;


            Assert.AreEqual(true, isRemovedCorrectly,
                string.Format("The method \"Remove\" does not work correctly!"));
        }

        [TestMethod]
        public void RemovingNoneExistingElementFromNoneEmptyDynamicListOfIntsShouldReturnMinusOne()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            var returnedValue = dynamicListOfInts.Remove(9);

            Assert.AreEqual(-1, returnedValue,
                string.Format("The method \"Remove\" does not work correctly when removing none existing number.\nShould return -1!" +
                              string.Format("returned value is {0}", returnedValue)));
        }

        [TestMethod]
        public void GettingIndexOfElementFromNoneEmptyDynamicListOfIntsShouldReturnCorrectIndex()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);
            int startingCount = dynamicListOfInts.Count;

            bool isIndexOperationSetCorrectly =
                dynamicListOfInts[0] == 1 &&
                dynamicListOfInts[1] == 2 &&
                dynamicListOfInts[2] == 3 &&
                dynamicListOfInts.Count == startingCount &&
                dynamicListOfInts.IndexOf(3) == 2;

            Assert.AreEqual(true, isIndexOperationSetCorrectly,
                string.Format("The method \"IndexOf\" does not work correctly!"));
        }

        [TestMethod]
        public void GettingIndexOfNoneExistingElementFromNoneEmptyDynamicListOfIntsShouldReturnMinusOne()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            var returnedValue = dynamicListOfInts.IndexOf(9);

            Assert.AreEqual(-1, returnedValue,
                string.Format("The method \"IndexOf\" does not work correctly when tring to get none existing number." +
                              string.Format("\nShould return -1 it returns {0}!", returnedValue)));
        }

        [TestMethod]
        public void ChekingForContainsElementInNoneEmptyDynamicListOfIntsShouldReturnTrue()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);
            int startingCount = dynamicListOfInts.Count;

            bool isContainedCorrectly =
                dynamicListOfInts[0] == 1 &&
                dynamicListOfInts[1] == 2 &&
                dynamicListOfInts[2] == 3 &&
                dynamicListOfInts.Count == startingCount &&
                dynamicListOfInts.Contains(2);

            Assert.AreEqual(true, isContainedCorrectly,
                string.Format("The method \"Contains\" does not work correctly!" +
                              string.Format("\n should return {0} it returns {1}", true, isContainedCorrectly)));
        }

        [TestMethod]
        public void ChekingForContainsNoneExistingElementInNoneEmptyDynamicListOfIntsShouldReturnTrue()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);
            int startingCount = dynamicListOfInts.Count;

            bool isContainedCorrectly =
                dynamicListOfInts[0] == 1 &&
                dynamicListOfInts[1] == 2 &&
                dynamicListOfInts[2] == 3 &&
                dynamicListOfInts.Count == startingCount &&
                dynamicListOfInts.Contains(8);

            Assert.AreEqual(false, isContainedCorrectly,
                string.Format("The method \"Contains\" does not work correctly!" +
                              string.Format("\n should return {0} it returns {1}", false, isContainedCorrectly)));
        }
    }
}