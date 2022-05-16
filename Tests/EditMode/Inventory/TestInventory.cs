using NUnit.Framework;

namespace SoulShard.Tests.InventorySystem
{
    class TestInventory
    {
        [Test]
        public void TestInventoryCapacity()
        {
            Assert.AreEqual(Helpers.GetFullInventory().capacity, 0);
            Assert.AreEqual(Helpers.GetHoleyInventory().capacity, 6);
        }
    }
}
