using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.DTO
{
    public class EdgeInput
    {
        public EdgeInput(string source, string target, RelationshipType relationshipType)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentException("message", nameof(target));
            }

            Source = source;
            Target = target;
            RelationshipType = relationshipType;
        }

        public string Source { get; }
        public string Target { get; }
        public RelationshipType RelationshipType { get; }
    }
}
