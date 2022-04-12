using RealEstateApp.API.Models;
using System.Collections.Generic;

namespace RealEstateApp.API.Validators
{
    public class PropertyImageValidator
    {

        public RealEstateAppContext Db { get; set; }
        public PropertyImage PropertyImage { get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
        public string Res { get; set; }

        public PropertyImageValidator(PropertyImage propertyImage)
        {
            PropertyImage = propertyImage;
        }

        public PropertyImageValidator(List<PropertyImage> propertyImages)
        {
            PropertyImages = propertyImages;
        }

        public PropertyImageValidator()
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
