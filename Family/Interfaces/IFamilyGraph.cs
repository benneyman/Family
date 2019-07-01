using Family.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Interfaces
{
    public interface IFamilyGraph
    {
        void AddRelationship(string source, string target, string relationshipType);
        void AddChild(string motherName, string childName, string gender);
    }
}
