using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    //#.-ISerializa -> Xml() : bool
    //              -> Path{ get; } : string
    public interface ISerializa
    {
        bool Xml();

        string Path { get; }
    }
}
