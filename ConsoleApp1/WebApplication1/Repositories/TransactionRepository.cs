using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories
{
    public static class TransactionRepository
    {
        private static readonly List<Transaction> _transactions = new List<Transaction>();

        public static List<Transaction> GetAll() => _transactions;

        public static void Add(Transaction transaction) => _transactions.Add(transaction);

        public static Transaction? GetById(Guid id) => _transactions.FirstOrDefault(t => t.TransactionId == id);
    }
}