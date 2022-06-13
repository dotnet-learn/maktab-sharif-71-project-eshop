﻿using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAggrigate.Contracts.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        Tag GetById(int id);
        void Create(Tag tag);
        void Update(Tag tag);
        void Remove(int id);
    }
}