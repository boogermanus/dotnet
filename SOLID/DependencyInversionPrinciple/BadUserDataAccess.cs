﻿namespace SOLID.DependencyInversionPrinciple;

public class BadUserDataAccess
{
    // this is basically a repository
    public User GetUser(int id)
    {
        var users = new List<User> { new(0, "boogermanus", false), new(1, "jordan.woodruff", true) };
        return users.First(u => u.Id == id);
    }
}