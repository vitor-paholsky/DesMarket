﻿using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Infrastructure.Base;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext { get; set; } 

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }
    public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
}
