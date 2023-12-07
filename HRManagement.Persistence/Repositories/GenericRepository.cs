﻿using HRManagement.Application.Contracts.Persistence;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly HrDatabaseContext _context;
    public GenericRepository(HrDatabaseContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
       await _context.AddAsync(entity);
       await _context.SaveChangesAsync();

    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
         _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}