﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseOopHierarchy;

public class Restaurant
{
    private List<Customer> _customers = new();
    private List<MenuItem> _menu = new();

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public MenuItem GetMenuItem(int index)
    {
        if (index < 0 || index >= _menu.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return _menu[index];
    }

    public void AddMenuItem(MenuItem menuItem)
    {
        _menu.Add(menuItem);
    }

    public void PlaceOrder(Customer customer, Order order)
    {
        customer.AddOrder(order);

        if (_customers.FirstOrDefault(customer) == null)
        {
            _customers.Add(customer);
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Items:");
        _menu.ForEach(m => Console.WriteLine(m));
    }

    public void DisplayOrderHistory(Customer customer)
    {
        Console.WriteLine($"{customer.Name}'s Order History:");
        customer.OrderHistory.ToList().ForEach(o => Console.WriteLine($"Order Total: ${o.GetTotal()}"));
        customer.OrderHistory.ToList().ForEach(o => o.Items.ToList().ForEach(i => Console.WriteLine("  " + i)));
    }
}
