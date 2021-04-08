using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal income = 0;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == nameof(Water))
            {
                drinks.Add(new Water(name,portion, brand));
            }
            if (type == nameof(Tea))
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == nameof(Bread))
            {
                bakedFoods.Add(new Bread(name, price));
            }
            if (type == nameof(Cake))
            {
                bakedFoods.Add(new Cake(name, price));
            }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == nameof(InsideTable))
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == nameof(OutsideTable))
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            List<Table> freeTables = tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            income += bill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            Drink drink = drinks.FirstOrDefault(x => x.Brand == drinkBrand&&x.Name==drinkName);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            BakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }           
        }
    }
}
