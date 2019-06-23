using Family.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Interfaces
{
    public interface IFamilyGraph
    {
        void Add(EdgeInput inputEdge);
        Edge GetEdge(EdgeInput inputEdge);
        IPersonRelationships Get(Person person);
    }
}
