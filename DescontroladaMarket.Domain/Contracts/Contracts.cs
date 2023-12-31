﻿using DescontroladaMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    void Create(T entity);
}