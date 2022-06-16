﻿using App.Domain.Core.BaseDataAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.Contracts.Repositories
{
    public interface IModelRepository
    {
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
        List<Model> GetAll();
        Model GetById(int id);
    }
}