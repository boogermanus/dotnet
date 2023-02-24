﻿namespace SOLID.DependencyInversionPrinciple;

public class GoodUserBusinessLogic
{
    private readonly IGoodUserDataAccess _dataAccess;

    public GoodUserBusinessLogic()
    {
        _dataAccess = GoodUserDataAccessFactory.GetUserDataAccess();
    }

    public User GeUser(int id)
    {
        return _dataAccess.GetUser(id);
    }
}