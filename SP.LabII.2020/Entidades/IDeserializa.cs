using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    //#.-IDeserializa -> Xml(out Lapiz) : bool
    public interface IDeserializa
    {
        bool Xml(out Lapiz lapiz);
    }
}
