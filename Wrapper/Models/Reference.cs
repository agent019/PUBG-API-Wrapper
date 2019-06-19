using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Represents a relationship between the object with this field, 
    /// and the referenced object.
    /// </summary>
    public class Relationship
    {
        public Reference Data { get; set; }
    }

    /// <summary>
    /// Represents a relationship between the object with this field,
    /// and a group of referenced objects.
    /// </summary>
    public class MultiRelationship
    {
        public List<Reference> Data { get; set; }
    }

    /// <summary>
    /// Represents an relational object that is a reference to some other object.
    /// </summary>
    public class Reference
    {
        public string Type { get; set; }
        public string Id { get; set; }
    }
    
    public class Links
    {
        public string Self { get; set; }
        public string Schema { get; set; }
    }

    public class Meta
    { }
}
