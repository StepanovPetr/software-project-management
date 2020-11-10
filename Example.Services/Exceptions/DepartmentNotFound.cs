using System;

namespace Example.Services.Exceptions
{
    public class DepartmentNotFound : Exception
    {
        public DepartmentNotFound(string mes) : base(mes)
        {
        }
    }
}