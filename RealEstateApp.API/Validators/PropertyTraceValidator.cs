using RealEstateApp.API.Models;
using System.Collections.Generic;

namespace RealEstateApp.API.Validators
{
    public class PropertyTraceValidator
    {

        public RealEstateAppContext Db { get; set; }
        public PropertyTrace PropertyTrace { get; set; }
        public List<PropertyTrace> PropertyTraces { get; set; }
        public string Res { get; set; }

        public PropertyTraceValidator(PropertyTrace propertyTrace)
        {
            PropertyTrace = propertyTrace;
        }

        public PropertyTraceValidator(List<PropertyTrace> propertyTraces)
        {
            PropertyTraces = propertyTraces;
        }

        public PropertyTraceValidator()
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
