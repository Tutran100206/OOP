using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Generic
{
    public class InMemoryRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly Dictionary<TKey, T> _store = new Dictionary<TKey, T>();
        private readonly Func<T, TKey> _keySelector;

        public InMemoryRepository(Func<T, TKey> keySelector)
        {
            _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector)); // ?? => null-coalescing
        }

        public void Add(T entity)
        {
            var key = _keySelector(entity);
            _store[key] = entity;
        }

        public T GetById(TKey id)
        {
            return _store.TryGetValue(id, out var entity) ? entity : null;
        }

        public IEnumerable<T> GetAll()
        {
            return _store.Values;
        }

        public void Update(T entity)
        {
            var key = _keySelector(entity);
            if (_store.ContainsKey(key))
            {
                _store[key] = entity;
            }
            else
            {
                throw new KeyNotFoundException($"Entity với khóa {key} không tồn tại.");
            }
        }

        public void Remove(TKey id)
        {
            if (_store.ContainsKey(id))
            {
                _store.Remove(id);
            }
            else
            {
                throw new KeyNotFoundException($"Entity với khóa {id} không tồn tại.");
            }
        }
    }
}
