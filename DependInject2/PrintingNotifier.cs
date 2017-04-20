using System.IO;

namespace DependInject2
{
    // A memo notifier that prints messages to a text stream. 
    public class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;

        // Construct the notifier with the stream onto which it will 
        // print notifications.
        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }

        // Print the details of an overdue memo onto the text stream.
        public void MemoIsDue(Memo memo)
        {
            _writer.WriteLine("Memo '{0}' is due!", memo.Title);
        }
    }
}
