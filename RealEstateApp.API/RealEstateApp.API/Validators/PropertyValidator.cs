using RealEstateApp.API.Models;
using System.Collections.Generic;

namespace RealEstateApp.API.Validators
{
    public class PropertyValidator
    {

        public RealEstateAppContext Db { get; set; }
        public Property Property { get; set; }
        public List<Property> Properties { get; set; }
        public string Res { get; set; }

        public PropertyValidator(Property property)
        {
            Property = property;
        }

        public PropertyValidator(List<Property> properties)
        {
            Properties = properties;
        }

        public PropertyValidator()
        {
        }

        public bool canGetResult()
        {
            return true;
        }

        public bool canSave()
        {
            return true;
        }
        public bool canUpdate()
        {
            return true;
        }

        public bool canDelete()
        {
            return true;
        }
    }
}
