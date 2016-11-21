using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using yodlee.ysl.api.beans;

namespace yodlee.ysl.api.parsers
{

    public interface Parser<T>
    {
        T parseJSON(string json);
    }
}
