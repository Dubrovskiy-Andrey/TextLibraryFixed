using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Fromatting
{
    public class ChangeCaseOperation : ITextOperation
    {
        private readonly bool _toUpper;

        public ChangeCaseOperation(bool toUpper)
        {
            _toUpper = toUpper;
        }

        public string Execute(string text)
        {
            return _toUpper ? text.ToUpper() : text.ToLower();
        }
    }
}
