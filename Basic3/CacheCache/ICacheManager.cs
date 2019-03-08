using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic3.CacheCache
{
    public interface ICacheManager : IDictionary<string, object>, IDisposable
    {
        T GetAs<T>(string key);
        void Add<T>(string key, T value);
        void Add<T>(string key, T value, TimeSpan expireIn);

        IList<string> FindKeys(string pattern);

        T AddOrGet<T>(string key, TimeSpan expireIn, Func<T> getValueAction);
    }
}
