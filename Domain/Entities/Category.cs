﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Icon {  get; private set; }

        public Category() { }
        public Category(Guid userId, string name, string icon)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Icon = icon;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void ChangeIcon(string newIcon)
        {
            Icon = newIcon;
        }
    }
}
