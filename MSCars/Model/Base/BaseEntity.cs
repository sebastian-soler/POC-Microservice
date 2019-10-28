﻿namespace MSCars.Model.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
