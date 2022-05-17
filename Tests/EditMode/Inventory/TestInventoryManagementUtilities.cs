using NUnit.Framework;
using SoulShard.InventorySystem;

public class TestInventorySystem
{
    [Test]
    public void TestAddInvalidItemToInventory()
    {
        var inven = Helpers.GetFullInventory();
        foreach (var fn in Helpers.addItemFuncs())
        {
            var res = fn(inven, new ItemInstance<BaseItem>());
            Assert.AreEqual(res.item, null);
            Assert.AreEqual(res.amount, 0);
        }
    }

    [Test]
    public void TestAddUnstackableItemToInventory()
    {
        var inven = Helpers.GetHoleyInventory();
        InventoryManagementUtilities.AddUnstackableItemToInventory(
            inven,
            new ItemInstance<BaseItem>(Helpers.witchesBrew)
        );
        InventoryManagementUtilities.AddUnstackableItemToInventory(
            inven,
            new ItemInstance<BaseItem>(Helpers.AXE)
        );
        InventoryManagementUtilities.AddUnstackableItemToInventory(
            inven,
            new ItemInstance<BaseItem>(Helpers.AXE)
        );
        Assert.AreEqual(inven.slots[1].itemInstance.item.name, Helpers.witchesBrew.name);
        Assert.AreEqual(inven.slots[2].itemInstance.item.name, Helpers.AXE.name);
        Assert.AreEqual(inven.slots[4].itemInstance.item.name, Helpers.AXE.name);
    }

    [Test]
    public void TestAddStackableItemToInventory()
    {
        var inven = Helpers.GetHoleyInventory();
        InventoryManagementUtilities.AddStackableItemToInventory(
            inven,
            new ItemInstance<BaseItem>(Helpers.salt, 10)
        );
        Assert.AreEqual(inven.slots[0].itemInstance.amount, 79);
        Assert.AreEqual(inven.slots[0].itemInstance.item.name, Helpers.salt.name);
        InventoryManagementUtilities.AddStackableItemToInventory(
            inven,
            new ItemInstance<BaseItem>(Helpers.salt, 30)
        );
        Assert.AreEqual(inven.slots[0].itemInstance.amount, 100);
        Assert.AreEqual(inven.slots[0].itemInstance.item.name, Helpers.salt.name);
        Assert.AreEqual(inven.slots[1].itemInstance.item.name, Helpers.salt.name);
        Assert.AreEqual(inven.slots[1].itemInstance.amount, 9);
    }

    [Test]
    public void TestInventoryContainsItem()
    {
        var inven = Helpers.GetHoleyInventory();
        Assert.AreEqual(
            InventoryManagementUtilities.ContainsItem(
                inven,
                new ItemInstance<BaseItem>(Helpers.salt, 69)
            ),
            true
        );
        Assert.AreEqual(
            InventoryManagementUtilities.ContainsItem(
                inven,
                new ItemInstance<BaseItem>(Helpers.salt, 39)
            ),
            false
        );
        Assert.AreEqual(
            InventoryManagementUtilities.ContainsItem(
                inven,
                new ItemInstance<BaseItem>(Helpers.AXE, 0)
            ),
            false
        );
        Assert.AreEqual(
            InventoryManagementUtilities.ContainsItem(
                inven,
                new ItemInstance<BaseItem>(Helpers.witchesBrew, 0)
            ),
            true
        );
    }
}
