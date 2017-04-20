using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependInject2
{
    public class MemoChecker
    {
        IQueryable<Memo> _memos;
        IMemoDueNotifier _notifier;

        // Construct a memo checker with the store of memos and the notifier 
        // that will be used to display overdue memos. 
        public MemoChecker(IQueryable<Memo> memos, IMemoDueNotifier notifier)
        {
            _memos = memos;
            _notifier = notifier;
        }

        // Check for overdue memos and alert the notifier of any that are found. 
        public void CheckNow()
        {
            var overdueMemos = _memos.Where(memo => memo.DueAt < DateTime.Now);

            foreach (var memo in overdueMemos)
            {
                _notifier.MemoIsDue(memo);
            }
        }
    }
}
