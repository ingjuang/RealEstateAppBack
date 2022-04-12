using RealEstateApp.API.Models;
using System.Collections.Generic;

namespace RealEstateApp.API.Validators
{
    public class OwnerValidator
    {

        public RealEstateAppContext Db { get; set; }
        public Owner Owner { get; set; }
        public List<Owner> Owners { get; set; }
        public string Res { get; set; }

        public OwnerValidator(Owner owner)
        {
            Owner = owner;
        }

        public OwnerValidator(List<Owner> owners)
        {
            Owners = owners;
        }

        public OwnerValidator()
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
