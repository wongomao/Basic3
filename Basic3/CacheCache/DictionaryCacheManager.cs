using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Basic3.CacheCache
{
    public class DictionaryCacheManager : Dictionary<string, object>, ICacheManager
    {
        public void Add<T>(string key, T value)
        {
            base.Add(key, value);
        }

        public void Add<T>(string key, T value, TimeSpan expireIn)
        {
            Add(key, value);
        }

        public T AddOrGet<T>(string key, TimeSpan expireIn, Func<T> getValueAction)
        {
            if (ContainsKey(key))
            {
                return GetAs<T>(key);
            }
            else
            {
                var val = getValueAction();
                Add(key, val, expireIn);
                return val;
            }
        }

        public IList<string> FindKeys(string pattern)
        {
            Regex regex = new Regex(pattern);
            return this.Keys.Where(k => regex.IsMatch(k)).ToList();
        }

        public T GetAs<T>(string key)
        {
            return (T)this[key];
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var disposable in this.Values.OfType<IDisposable>())
                    {
                        disposable.Dispose();
                    }
                }

                this.Clear();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DictionaryCacheManager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
