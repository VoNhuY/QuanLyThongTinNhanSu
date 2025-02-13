﻿namespace Entities.Exceptions.BaseExceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base($"Not found: '{message}'")
        { }
    }
}
