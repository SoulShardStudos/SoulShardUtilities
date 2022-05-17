using NUnit.Framework;
using UnityEngine;
using SoulShard.Utils;
using System.Linq;

class TestCollectionUtility
{
    [Test]
    public void TestGetComponentFromGameObjectList()
    {
        SpriteRenderer[] res = CollectionUtility
            .GetComponentFromGameObjectList<SpriteRenderer>(
                new GameObject[5]
                {
                    new GameObject("1", components: new System.Type[1] { typeof(SpriteRenderer) }),
                    new GameObject("2"),
                    new GameObject("3", components: new System.Type[1] { typeof(SpriteRenderer) }),
                    new GameObject("4"),
                    new GameObject("5", components: new System.Type[1] { typeof(SpriteRenderer) })
                }
            )
            .ToArray();
        Assert.NotNull(res[0]);
        Assert.NotNull(res[2]);
        Assert.NotNull(res[4]);
        Assert.Null(res[1]);
        Assert.Null(res[3]);
        Assert.AreEqual(res.Length, 5);
    }

    [Test]
    public void TestCollectionCountOccurences()
    {
        var @default = "HELLO!!!";
        Assert.AreEqual(CollectionUtility.Gen(5, @default).CountOccurences(@default), 5);
        Assert.AreEqual(
            new string[5]
            {
                @default,
                @default,
                "hello00000!!!!@#$!",
                @default,
                "GOODBYE!"
            }.CountOccurences(@default),
            3
        );
        Assert.AreEqual(CollectionUtility.Gen(5, "nope").CountOccurences(@default), 0);
    }

    [Test]
    public void TestBetterToString()
    {
        var inp = new GameObject[5]
        {
            new GameObject("1", components: new System.Type[1] { typeof(SpriteRenderer) }),
            null,
            new GameObject("3", components: new System.Type[1] { typeof(SpriteRenderer) }),
            new GameObject("4"),
            new GameObject("5", components: new System.Type[1] { typeof(SpriteRenderer) })
        };
        Assert.AreEqual(
            inp.BetterToString(delimiter: ","),
            "1 (UnityEngine.GameObject),,3 (UnityEngine.GameObject),4 (UnityEngine.GameObject),5 (UnityEngine.GameObject)"
        );
        Assert.AreEqual(
            inp.BetterToString((GameObject s) => $"{s?.name ?? "NULL"} GAMEOBJECT INSTANCE"),
            "1 GAMEOBJECT INSTANCE, NULL GAMEOBJECT INSTANCE, 3 GAMEOBJECT INSTANCE, 4 GAMEOBJECT INSTANCE, 5 GAMEOBJECT INSTANCE"
        );
    }

    [Test]
    public void TestGen()
    {
        Assert.AreEqual(
            CollectionUtility.Gen(2, 2, "bunger"),
            new string[2, 2] { { "bunger", "bunger" }, { "bunger", "bunger" } }
        );
        Assert.AreEqual(CollectionUtility.Gen(2, "bunger"), new string[2] { "bunger", "bunger" });
    }
}
