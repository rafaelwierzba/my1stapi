﻿using BookAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Delete(int Id)
        {
            var bookToDelete = await _context.Books.FindAsync(Id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return null;

        }

        public async Task<IEnumerable<Book>> Get()
        {
          return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task<Book> Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
             await _context.SaveChangesAsync();
            return book;
        }
    }
}
