﻿namespace EatOutByBI.Data.Classes
{
    public interface IObjectWithState
    {
        ObjectState ObjectState { get; set; }

    }

    public enum ObjectState
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
}
