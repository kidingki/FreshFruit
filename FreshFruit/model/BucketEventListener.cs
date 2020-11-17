using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFruit.model
{
    interface BucketEventListener
    {
        void onSucceed(string message);
        void onFailed(string message);
    }
}