using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Extention
{
    public static class StringExtentions
    {
        public static Gender ToGenderEnum(this string input)
        {
            return input == "Male" ? Gender.Male : Gender.Female;
        }
        public static RelationshipType ToRelationshipEnum(this string input)
        {
            return input == "Parent" ? RelationshipType.Parent : RelationshipType.Spouse;
        }
        
    }
}
