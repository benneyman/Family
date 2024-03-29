﻿using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.DTO
{
    internal sealed class Relationship
    {
        public Relationship(Person source, Person target, RelationshipType relationshipType)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Target = target ?? throw new ArgumentNullException(nameof(target));
            RelationshipType = relationshipType;
        }

        public Person Source { get; }
        public Person Target { get; }
        public RelationshipType RelationshipType { get; }
    }
}
