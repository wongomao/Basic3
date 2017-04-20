using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependInject2
{
    public interface IMemoDueNotifier
    {
        void MemoIsDue(Memo memo);
    }
}
