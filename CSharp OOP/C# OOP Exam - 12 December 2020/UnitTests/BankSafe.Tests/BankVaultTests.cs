using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        private Item otherItem;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Evtim", "id");
            otherItem = new Item("Mitko", "otherId");
        }

        //Testing adding items to vault
        [Test]
        public void AddingItemInWrongVaultCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("wrongCell", item));
        }

        [Test]
        public void AddingItemInFilledVaultCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", otherItem));
        }

        [Test]
        public void AddingSameItemInVaultCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void ChecksIfItemIsAdded()
        {
            bankVault.AddItem("A1", item);
            Assert.That(item, Is.EqualTo(bankVault.VaultCells["A1"]));
        }

        [Test]
        public void ChecksIfRightStringIsReturnedAfterAdding()
        {
            string result = bankVault.AddItem("A1", item);
            Assert.That(result, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        //Testing removing items from vault
        [Test]
        public void RemovingItemFromWrongVaultCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("wrongCell", item));
        }

        [Test]
        public void RemovingWrongItemFromVaultCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", otherItem));
        }

        [Test]
        public void ChecksIfItemIsRemoved()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.That(null, Is.EqualTo(bankVault.VaultCells["A1"]));
        }

        [Test]
        public void ChecksIfRightStringIsReturnedAfterRemoving()
        {
            bankVault.AddItem("A1", item);
            string result = bankVault.RemoveItem("A1", item);
            Assert.That(result, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }

        //Checks if initiating bankVault is right
        [Test]
        public void CtorCheck()
        {
            Dictionary<string, Item> vaultCells = new Dictionary<string, Item>()
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            Assert.That(bankVault.VaultCells, Is.EqualTo(vaultCells));
        }

    }
}